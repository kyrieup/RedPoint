using System.Collections.Generic;
using System;
using UnityEngine;
class RedPointSystem
{
    public delegate void OnRedPointNumChange(RedPointNode node);
    RedPointNode mainNode;
    public List<string> RedPoints = new List<string> {
        RedPointConst.main,
        RedPointConst.task,
        RedPointConst.mail,
        RedPointConst.mailTest,
        RedPointConst.mailTask,
        RedPointConst.test,

        };


    public void InitRedPoint() 
    {
        mainNode = new RedPointNode();
        mainNode.nodeName = RedPointConst.main;
        foreach (var item in RedPoints)
        {
            RedPointNode tempNode = mainNode;
            string[] nameList = item.Split(".");
            if (nameList[0] != "Main")
            {
                Debug.LogError("这个树不对:" + nameList[0]);
            }
            if (nameList.Length>1)
            {
                for (int i = 1; i < nameList.Length; i++)
                {
                    if (! tempNode.sonNodes.ContainsKey(nameList[i]))
                    {
                        tempNode.sonNodes.Add(nameList[i], new RedPointNode());
                    }
                    tempNode.sonNodes[nameList[i]].nodeName = nameList[i];
                    tempNode.sonNodes[nameList[i]].parentNode = tempNode;
                    tempNode = tempNode.sonNodes[nameList[i]];
                }
            }
        }
    
    }

    public void SetCallBack(string nodeUrl, OnRedPointNumChange callback)
    {
        GetRedPointNode(nodeUrl).onRedPointNumChange += callback;
    }
    public void InvokeCallBack(string nodeUrl)
    {
       // GetRedPointNode(nodeUrl).onRedPointNumChange.Invoke();
    }

    public void SetRedNodeNum(string nodeUrl,int num) 
    {
        GetRedPointNode(nodeUrl).SetNum(num);
    
    
    }

    private RedPointNode GetRedPointNode(string nodeUrl) 
    { 
        string[] nameList = nodeUrl.Split(".");

        if (nameList[0] != RedPointConst.main)
        {
            Debug.LogError("这个树不对:" + nameList[0]);
            return null;
        }
        RedPointNode node = mainNode;
        for (int i = 1; i < nameList.Length; i++)
        {
            if (!node.sonNodes.ContainsKey(nameList[i]))
            {
                Debug.Log("不包含这个节点");
            }
            node = node.sonNodes[nameList[i]];
        }
        return node;
    
    
    }
}

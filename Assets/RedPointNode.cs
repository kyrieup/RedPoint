using System.Collections.Generic;
using UnityEngine;
class RedPointNode 
{
    public string nodeName;
    public int redPointNum = 0;
    public RedPointNode parentNode;
    public RedPointSystem.OnRedPointNumChange onRedPointNumChange;

    public Dictionary <string, RedPointNode> sonNodes=new Dictionary<string, RedPointNode>();

    public void SetNum(int num) 
    {
        //if (sonNodes.Count>0)
        //{
        //    Debug.LogError("只能设置叶子节点");
        //    return;
        //}
        if (redPointNum == num)
        {
            Debug.Log("红点数量没变化");
        }
        else
        {
            parentNode?.SetNum(num);
            redPointNum = num;
            Debug.Log(nodeName + redPointNum);
            onRedPointNumChange?.Invoke(this);
        }

    }

}

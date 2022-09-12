using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button a;
    RedPointSystem l;
    public int num = 0;    
    // Start is called before the first frame update
    void Start()
    {
        l= new RedPointSystem();
        l.InitRedPoint();
        
        a.onClick.AddListener(() => {
            num = num + 1; 
            l.SetRedNodeNum(RedPointConst.mailTask, num); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

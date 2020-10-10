using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Groundを管理（タップ）
public class GroundManager : MonoBehaviour
{
    void Start() 
    {
        //DrawLines();
    }
    //関数登録（針を降らす）
    Action tapAction; //クリックされたときに実行したい関数

    //tapActionに関数を登録する関数
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap() 
    {
        tapAction();
    }

    //groundのlineをlineRendererで引く場合
    /*
    public void DrawLines()
    {
        List<Vector3> myPoint = new List<Vector3>();

        float baseX = 5.0f;
        float baseY = 0.102f;
        float baseZ = 1.6f;

        LineRenderer LRend = GetComponent<LineRenderer>();
        LRend.SetWidth(0.04f,0.04f);
        while (baseZ > -2.5f) 
        {
            myPoint.Add(new Vector3(-baseX,baseY,baseZ));
            myPoint.Add(new Vector3(baseX, baseY, baseZ));
            baseZ -= 0.8f;
            myPoint.Add(new Vector3(baseX, baseY, baseZ));
            myPoint.Add(new Vector3(-baseX, baseY, baseZ));
            baseZ -= 0.8f;
        }
        int count = 0;
        foreach (var v in myPoint)
        {
            LRend.positionCount = count + 1;
            LRend.SetPosition(count, myPoint[count]);
            ++count;
        }
    }
    */
}
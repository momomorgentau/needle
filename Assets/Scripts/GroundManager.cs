using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Groundを管理（タップ）
public class GroundManager : MonoBehaviour
{
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
}
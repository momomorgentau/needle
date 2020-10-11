using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ExplainManager : MonoBehaviour
{
    //private gameObject childObject;
    private int count;
    private GameObject childObject;
    private ChangeSprite changeSprite;
    [SerializeField]
    private GameObject[] buttonObject;

    void Start() 
    {
        //childObject = transform.GetChild(0).gameObject;
        count = 0;
        childObject = transform.GetChild(0).gameObject;
        changeSprite = childObject.GetComponent<ChangeSprite>();
        SetActiveButton(count);
    }
    //クリックされたときの挙動
    public void OnClickCountChange(int a)
    { 
        count += a;
        if (count < 0) count = 0;
        if (count > 3) count = 3;
        changeSprite.ChangeImage(count);
        SetActiveButton(count);
    }
    //ボタンの種類の切り替え
    public void SetActiveButton(int a) 
    {
        if (a == 0)
        {
            buttonObject[0].SetActive(false);
            buttonObject[1].SetActive(true);
            buttonObject[2].SetActive(false);
        }
        else if (a == 1 || a == 2) 
        {
            buttonObject[0].SetActive(true);
            buttonObject[1].SetActive(true);
            buttonObject[2].SetActive(false);
        }
        else
        {
            buttonObject[0].SetActive(true);
            buttonObject[1].SetActive(false);
            buttonObject[2].SetActive(true);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

//セーブデータを管理する
public class PlayerSaveData : MonoBehaviour
{
    //セーブデータのセーブ
    public void Save(int currentNeedle, int touchNeedle) 
    {
        PlayerPrefs.SetInt("existNeedleCount", currentNeedle);
        PlayerPrefs.SetInt("touchNeedleCount", touchNeedle);
    }
    //ロード
    public int Load(string name)
    {
        var value = PlayerPrefs.GetInt(name);
        if (value == null) return 0;
        else return value;
    }
    //デリート
    public void Delete() 
    {
        PlayerPrefs.SetInt("existNeedleCount", 0);
        PlayerPrefs.SetInt("touchNeedleCount", 0);
    }


}

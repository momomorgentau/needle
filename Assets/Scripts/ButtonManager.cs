using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{

    public void OnClickSceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //gameからtitleに戻る際にセーブをする。
    public void OnClickGame2Title() 
    {
        GameManager.instance.Go2Title();
        SceneManager.LoadScene("Title");

    }

}


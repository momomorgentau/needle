using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TitleのUIを管理（シーン遷移以外）
public class TitleUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject deleteWindow;
    [SerializeField]
    private GameObject afterDeleteWindow;
    [SerializeField]
    private GameObject saveDataManager;
    [SerializeField]
    private PlayerSaveData playerSaveData;
    [SerializeField]
    private GameObject basicButtons;

    void Start() 
    {
        deleteWindow.SetActive(false);
        afterDeleteWindow.SetActive(false);
        basicButtons.SetActive(true);

        playerSaveData = saveDataManager.GetComponent<PlayerSaveData>();
    }
    //デリートボタンを押した処理
    public void OnClickDeleteButton() 
    {
        deleteWindow.SetActive(true);
        basicButtons.SetActive(false);

    }
    //はいボタンを押した処理
    public void OnClickYesButton() 
    {
        playerSaveData.Delete();
        afterDeleteWindow.SetActive(true);
        deleteWindow.SetActive(false);
    }
    //いいえボタンを押した処理
    public void OnClickNoButton()
    {
        deleteWindow.SetActive(false);
        basicButtons.SetActive(true);

    }
    //もどるボタンを押した処理
    public void OnClickReturnButton()
    {
        deleteWindow.SetActive(false);
        afterDeleteWindow.SetActive(false);
        basicButtons.SetActive(true);


    }

}

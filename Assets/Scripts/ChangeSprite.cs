using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSprite : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        // topObject = transform.GetChild(0).gameObject;
    }

    public void ChangeImage(int a) 
    {
        image.sprite = sprites[a]; 
    }
}

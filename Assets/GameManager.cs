
using System.Collections;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GroundManager groundManager;
    public static GameManager instance;
    [SerializeField]
    private GameObject needleObj;
    [SerializeField]
    private GameParameter gameParameter;
    [SerializeField]
    private GameObject upperRight;
    //[SerializeField]
    //private GameObject upperLeft;
    //[SerializeField]
    //private GameObject lowerRight;
    [SerializeField]
    private GameObject lowerLeft;
    private float xMax;
    private float xMin;
    private float zMax;
    private float zMin;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start() {
        Setup();  
    }

    public void Setup() 
    {
        
        groundManager.AddEventListenerOnTap(CreateNeedle);
        xMax = upperRight.transform.position.x;
        xMin = lowerLeft.transform.position.x;
        zMax = upperRight.transform.position.z;
        zMin = lowerLeft.transform.position.z;
        Debug.Log(xMax);
        Debug.Log(xMin);
        Debug.Log(zMax);
        Debug.Log(zMin);

    }

    public void CreateNeedle()
    {
        float x, z;
        var qua = Random.rotation;
        x = UnityEngine.Random.Range(xMax, xMin);

        z = UnityEngine.Random.Range(zMax, zMin);
        Instantiate(needleObj, new Vector3(x, 5.0f, z), qua);
    }
    
}

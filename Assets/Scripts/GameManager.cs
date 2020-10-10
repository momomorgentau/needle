using System.Collections.Specialized;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GroundManager groundManager;
    public static GameManager instance;
    public UIManager uiManager;
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
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
    //針の長さ
    public float needleLength;
    //針の最大値
    public int maxNeedleNum;
    //判定するまでの時間
    public float delayTime;
    //消えるまでの時間
    public int destroyTime;
    
    public struct Score{
        public int existNeedleCount;
        public int touchNeedleCount;
        public float pi;
        public Score(int e, int t, float p) 
        {
            existNeedleCount = e;
            touchNeedleCount = t;
            pi = p;
        }

        public void cal()
        {
            if (touchNeedleCount == 0) pi = 0.0f;
            else pi = (float) existNeedleCount / touchNeedleCount;
        }
    }
    public Score score = new Score(0,0,0.0f);


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        Setup();  
    }

    public void Setup() 
    {
        
        groundManager.AddEventListenerOnTap(CreateNeedle);
        //画面に置いたキューブから取得
        xMax = upperRight.transform.position.x;
        xMin = lowerLeft.transform.position.x;
        zMax = upperRight.transform.position.z;
        zMin = lowerLeft.transform.position.z;
        //scriptbleObjectから取得
        needleLength = gameParameter.needleLength;
        uiManager.UpdateScore(score.existNeedleCount, score.touchNeedleCount, score.pi);
        maxNeedleNum = gameParameter.maxNeedleNum;
        delayTime = gameParameter.delayTime;
        destroyTime = gameParameter.destroyTime;




    }

    public void CreateNeedle()
    {
        float x, z;
        var qua = Random.rotation;
        x = UnityEngine.Random.Range(xMax, xMin);
        z = UnityEngine.Random.Range(zMax, zMin);
        Instantiate(needleObj, new Vector3(x, 5.0f, z), qua);

        ++score.existNeedleCount;
        score.cal();
        uiManager.UpdateScore(score.existNeedleCount, score.touchNeedleCount,score.pi);
    }

    public void UIupdate() 
    {
        uiManager.UpdateScore(score.existNeedleCount, score.touchNeedleCount, score.pi);
    }




    
}

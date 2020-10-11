using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GroundManager groundManager;
    public static GameManager instance;
    public UIManager uiManager;
    private PlayerSaveData playerSaveData;
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
    

    const double ansPi = 3.14159265358979;
    
    public struct Score{
        public int existNeedleCount;
        public int touchNeedleCount;
        public double pi;
        public double def;
        public Score(int e, int t, float p) 
        {
            existNeedleCount = e;
            touchNeedleCount = t;
            pi = p;
            def = 0.0f;
        }

        public void cal()
        {
            if (touchNeedleCount == 0) pi = 0.0f;
            else pi = (double) existNeedleCount / touchNeedleCount;
            def = Abs(ansPi, pi);
        }

        private double Abs(double a, double b)
        {
            double c = a - b;
            if (c < 0) c *= -1;
            return c;
        }
    }

    public Score score = new Score(0, 0, 0.0f);



    //staticだけどシングルトンにはしない
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }

    void Start() {
        Setup();  
    }

    public void Setup() 
    {
        playerSaveData = GetComponent<PlayerSaveData>();
        groundManager.AddEventListenerOnTap(CreateNeedle);
        //画面に置いたキューブから取得
        xMax = upperRight.transform.position.x;
        xMin = lowerLeft.transform.position.x;
        zMax = upperRight.transform.position.z;
        zMin = lowerLeft.transform.position.z;
        //scriptbleObjectから取得
        needleLength = gameParameter.needleLength;

        //セーブデータをロード
        score.existNeedleCount = playerSaveData.Load("existNeedleCount");
        score.touchNeedleCount = playerSaveData.Load("touchNeedleCount");

        UIupdate();
        maxNeedleNum = gameParameter.maxNeedleNum;
        delayTime = gameParameter.delayTime;
        destroyTime = gameParameter.destroyTime;

        




    }
    //針を生成
    public void CreateNeedle()
    {
        float x, z;
        var qua = Random.rotation;
        x = UnityEngine.Random.Range(xMax, xMin);
        z = UnityEngine.Random.Range(zMax, zMin);
        Instantiate(needleObj, new Vector3(x, 5.0f, z), qua);

        ++score.existNeedleCount;

        UIupdate();
    }
    //UIを更新する処理
    public void UIupdate() 
    {
        score.cal();
        uiManager.UpdateScore(score.existNeedleCount, score.touchNeedleCount, score.pi,score.def);
    }
    //gameからtitleに戻るときに行う処理
    public void Go2Title() 
    {
        playerSaveData.Save(score.existNeedleCount,score.touchNeedleCount);
    }




    
}

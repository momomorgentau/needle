using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//針に関する挙動を制御
public class NeedleManager : MonoBehaviour
{
    private GameObject topObject;
    private GameObject buttomObject;
    private float z1, z2;
    private int initCount;
    private int maxNeedleNum;
    private float delayTime;
    private int destroyTime; 

    // Start is called before the first frame update
    void Start()
    {
        topObject = transform.GetChild(0).gameObject;
        buttomObject = transform.GetChild(1).gameObject;

        initCount = GameManager.instance.score.existNeedleCount;
        maxNeedleNum = GameManager.instance.maxNeedleNum;
        destroyTime = GameManager.instance.destroyTime;

        StartCoroutine("Judge");
        StartCoroutine("DestroyNeedle");
    }
    //接触したかどうかの判定（生成後 delaytime秒で判定）
    IEnumerator Judge()
    {
        yield return new WaitForSeconds(delayTime);
        z1 = topObject.transform.position.z;
        z2 = buttomObject.transform.position.z;
        if (z1 <= z2) {
            float tmp;
            tmp = z1;
            z1 = z2;
            z2 = tmp;
        }

        float zmax = GameManager.instance.zMax;
        float zmin = GameManager.instance.zMin;
        float width = GameManager.instance.needleLength * 2;

        float line = 0.0f;
        if (z1 > 0.0f)
        {
            while (line <= z1)
            {
                if (z1 >= line && line >= z2)
                {
                    ++GameManager.instance.score.touchNeedleCount;
                    GameManager.instance.UIupdate();
                    break;
                }
                line += width;
            }
        }
        else
        {
            while (line >= z2)
            {
                if (z1 >= line && line >= z2)
                {
                    ++GameManager.instance.score.touchNeedleCount;
                    GameManager.instance.UIupdate();
                    break;
                }
                line -= width;
            }
        }


    }
    //針を消す処理
    IEnumerator DestroyNeedle()
    {
        int currentNeedleNum;
        while (true)
        {
            currentNeedleNum = GameManager.instance.score.existNeedleCount;
            int spentNeedle = currentNeedleNum - initCount;
            if (spentNeedle > maxNeedleNum)
            {
                Destroy(this.gameObject);
                break;
            }
            yield return new WaitForSeconds(destroyTime);
            
        }
    }
}

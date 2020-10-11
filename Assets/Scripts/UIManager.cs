
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text existNeedleCountText;
    [SerializeField]
    private Text touchNeedleCountText;
    [SerializeField]
    private Text piText;
    [SerializeField]
    private Text defText;


    public void UpdateScore(int existNeedleCount, int touchNeedleCount, double pi, double def) 
    {
        existNeedleCountText.text = string.Format("{0}", existNeedleCount) ;
        touchNeedleCountText.text = string.Format("{0}", touchNeedleCount);
        piText.text = string.Format("{0}",pi);
        defText.text = string.Format("{0}", def);

    }

}

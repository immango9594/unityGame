using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    // 用于遮盖血条的mask
    private Image targetMask;

    private GameObject redMask;

    private GameObject blueMask;

    private GameObject yellowMask;
    // 血条初始宽度
    private float initRedWidth;

    private float initBlueWidth;

    private float initYellowWidth;

    // 单例模式
    public static health instance { private set; get; }

    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        redMask = transform.Find("RedMask").gameObject;
        blueMask = transform.Find("BlueMask").gameObject;
        yellowMask = transform.Find("YellowMask").gameObject;
        initRedWidth = redMask.GetComponent<Image>().rectTransform.rect.width;
        initBlueWidth = blueMask.GetComponent<Image>().rectTransform.rect.width;
        initYellowWidth = yellowMask.GetComponent<Image>().rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWidth(float percent, string type) {
        if (type == "Red") 
        {
            redMask.GetComponent<Image>().rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initRedWidth * percent);
        }
        if (type == "Blue")
        {
            blueMask.GetComponent<Image>().rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initBlueWidth * percent);
        }
        if (type == "Yellow")
        {
            yellowMask.GetComponent<Image>().rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initYellowWidth * percent);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLittle : MonoBehaviour
{
    // 遮盖用mask
    public Image mask;

    // 血条初始宽度
    private float initWidth;
    void Start()
    {
        initWidth = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setWidth(float percent)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initWidth * percent);
    }
}

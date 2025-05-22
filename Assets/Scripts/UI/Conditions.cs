using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour
{
    public float startValue;
    public float maxValue;

    private float curretValue;
    public float CurretValue {  get { return curretValue; } set { curretValue = value; } }

    [SerializeField] private float passiveValueDecrease;
    public float PassiveValueDecrease {  get { return passiveValueDecrease; } set { passiveValueDecrease = value; } }

    [SerializeField] private float passiveValueIncrease;
    public float PassiveValueIncrease { get { return passiveValueIncrease; } set { PassiveValueIncrease = value; } }

    public float oneHeart;
    public List<Image> imageList = new List<Image>();
    public Image uiBar;

    // Start is called before the first frame update
    void Start()
    {
        curretValue = startValue;       

        oneHeart = curretValue / imageList.Count;

        for (int i = 0; i < imageList.Count; i++)
        {
            imageList[i].fillAmount = oneHeart;
        }
    }

    // Update is called once per frame
    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }
    private float GetPercentage()
    {
        return curretValue / maxValue;
    }
    public void Add(float value)
    {
        curretValue = Mathf.Min(curretValue + value, maxValue); 
    }
    public void Subtract(float value)
    {
        curretValue = Mathf.Max(curretValue - value, 0);
    }
}

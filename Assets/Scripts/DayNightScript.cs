using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    public Transform Moon;
    public Light MoonLight;
    public int DaysCount = 0;
    float num;
    void Start()
    {
        Moon.rotation = Quaternion.Euler(180 , 0, 0);
        MoonLight.intensity = 0.1f;
    }
    void Update()
    {
        gameObject.transform.Rotate(0.5f * Time.deltaTime, 0, 0);
        Moon.transform.Rotate(0.5f * Time.deltaTime, 0, 0);
    }

}

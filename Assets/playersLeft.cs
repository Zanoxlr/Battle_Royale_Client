using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class playersLeft : MonoBehaviour
{
    public Text playersLeftTxt;
    public Text countDownTxt;
    public int count;
    float num = 60;
    bool startRound = false;
    void Update()
    {
        count = NetworkServer.connections.Count;
        playersLeftTxt.text = count.ToString() + " Players left";
        if (count >= 2)
        {
            Debug.Log("hey Vsauce");
            StartZoneMethod();
        }
        if(startRound == true)
        {
            countDownTxt.text = Mathf.Round(num -= Time.deltaTime).ToString() + " Seconds left to start";
            if (num <= 0)
            {
                countDownTxt.text = null;
                GetComponent<Zone>().PauseMethod();
                startRound = false;
            }
        }
    }
    void StartZoneMethod()
    {
        startRound = true;
    }
}

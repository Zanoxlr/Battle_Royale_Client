using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    public Text ErrorMessage; 
    public InputField ipAddress;
    // KillFeed
    public Text killer;
    public Text killed;
    public GameObject ak47;
    public GameObject deagle;
    public Text killCountTxt;
    public GameObject KillFeedGO;
    public Text timerTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    public void ConnectToServer()
    {
        string ip = ipAddress.text;
        Client.instance.NewStart(ip);

        if (Client.instance.isConnected)
        {
            MenuToggle(true);
        }
        else
        {
            ErrorMessage.text = "Type a correct IP address or input your username";
        }
    }
    public void KillFeed(string _killer,string _killed,int _weaponId)
    {
        killer.text = _killer;
        killed.text = _killed;
        if(_weaponId == 1)
        {
            ak47.SetActive(true);
            deagle.SetActive(false);
        }
        else if (_weaponId == 2)
        {
            ak47.SetActive(false);
            deagle.SetActive(true);
        }
    }
    public void KillCount(int _killCount)
    {
        killCountTxt.text = _killCount.ToString();
    }
    public void TimerTxtChange(int timer, string message)
    {
        if (timer >= 0)
        {
            timerTxt.text = timer.ToString() + message;
        }
        else
        {
            timerTxt.text = message;
        }
    }
    public void MenuToggle(bool toggle)
    {
        startMenu.SetActive(!toggle);
        KillFeedGO.SetActive(toggle);
        usernameField.interactable = !toggle;
        ipAddress.interactable = !toggle;
    }
}

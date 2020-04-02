using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float health = 100;
    public int weaponId = 0;
    public int ammo = 0;
    public int ammoInMag = 0;
    public Text ammoTxt;
    public Text ammoInMagTxt;
    public Text healthTxt;
    public Text maxAmmoInMag;
    public Text placementTxt;
    public GameObject dEagleObject;
    public GameObject ak47Object;
    public Text timerTxt;
    public PostProcessVolume TheRightPPV;
    public void WeaponSwitch()
    {
        if (weaponId == 1)
        {
            ak47Object.SetActive(true);
            dEagleObject.SetActive(false);
            maxAmmoInMag.text = "/ 30";
            ammoInMagTxt.text = ammoInMag.ToString();
        }
        else if (weaponId == 2)
        {
            ak47Object.SetActive(false);
            dEagleObject.SetActive(true);
            maxAmmoInMag.text = "/ 7";
            ammoInMagTxt.text = ammoInMag.ToString();
        }
    }
    public void HealthTxtChange(float _health)
    {
        health = _health;
        healthTxt.text = Mathf.RoundToInt(health).ToString();
    }
    public void AmmoTxtChange(int _ammo)
    {
        ammo = _ammo;
        ammoTxt.text = ammo.ToString();
    }
    public void AmmoInMagTxtChange(int _ammoInMag)
    {
        ammoInMag = _ammoInMag;
        ammoInMagTxt.text = ammoInMag.ToString();
    }
    public void pPE(bool postProcesingEffect)
    {
        if (postProcesingEffect == true)
        {
            TheRightPPV.enabled = false;
        }
        else
        {
            TheRightPPV.enabled = true;
        }
    }
    public void Placement(int placement)
    {
        if (placement >= 2)
        {
            placementTxt.text =  "You were " + placement.ToString() + ".";
        }
        else
        {
            placementTxt.text = "You Won, Congratulations";
        }
    }
}
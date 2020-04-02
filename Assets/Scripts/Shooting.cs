using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour
{
   /* public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject impactEffect;
    public float impactForce = 30f;
    public float fireRate = 15;
    private float nextTimeToFire = 0;
    public int weaponId;
    int previousId = 0;
    private AudioSource m_AudioSource;
    AudioClip normalClip;
    public GameObject gunParent;
    public AudioClip dEagleClip;
    public AudioClip ak47Clip;
    public GameObject dEagleObject;
    public GameObject ak47Object;
    public GameObject ammoObject;
    public AudioClip outOfAmmo;
    public AudioClip reloadingSound;
    public AudioClip hitSound;
    public int ammo = 30;
    int maxAmmoInMag = 7;
    int ammoInMag = 7;
    float pickUpRange = 3f;
    public Text mAIMTxt;
    public Text ammoTxt;
    public Text aIMTxt;
    public Text dash;
    bool isReloading;
    GameObject clone;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        mAIMTxt.text = maxAmmoInMag.ToString();
        aIMTxt.text = ammoInMag.ToString();
    }
    void Update()
    {
        // Fire
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && isReloading == false && weaponId != 0)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            if (ammoInMag > 0)
            {
                ammoInMag -= 1;
                aIMTxt.text = ammoInMag.ToString();
                Shoot();
                m_AudioSource.PlayOneShot(normalClip, 0.1f);
            }
            else
            {
                m_AudioSource.PlayOneShot(outOfAmmo, 0.1f);
            }
        }
        // Interact
        if (Input.GetButtonUp("Interact"))
        {
            PickingUpPickables();
        }
        // Reload
        if (Input.GetButtonDown("Reload") && ammoInMag != maxAmmoInMag)
        {
            if (ammo == 0)
            {
                m_AudioSource.PlayOneShot(outOfAmmo, 0.1f);
            }
            else
            {
                StartCoroutine(ReloadingMethod());
            }
        }
        if(weaponId == 0)
        {
            mAIMTxt.text = null;
            aIMTxt.text = null;
            dash.text = null;
        }
        else
        {
            dash.text = "/";
        }
    }
    [Client]
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, hit.transform.position);
            }
        }
        GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGo, 1f);
    }
    void PickingUpPickables()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, pickUpRange))
        {
            weaponId = hit.transform.GetComponent<IdOnItems>().id;
            // AK-47
            if (weaponId == 1)
            {
                // seting the parameters
                fireRate = 11;
                damage = 10;
                range = 80;
                maxAmmoInMag = 30;
                ammoInMag = 0;
                // set the ammo sound
                normalClip = ak47Clip;
                // disabling other objects
                ak47Object.SetActive(true);
                dEagleObject.SetActive(false);
                // setting the mag info
                aIMTxt.text = ammoInMag.ToString();
                mAIMTxt.text = maxAmmoInMag.ToString();
                // destroying gun that i picked up
                Destroy(hit.transform.gameObject);
                // droping gun 
                if (previousId != 0 && weaponId != previousId)
                {
                    Destroy(clone);
                    clone = Instantiate(dEagleObject, gameObject.transform.position, transform.rotation, null);
                    clone.SetActive(true);
                    previousId = 1;
                }
                else
                {
                    previousId = 1;
                }
            }
            // DesertEagle
            if (weaponId == 2)
            {
                // seting the parameters
                fireRate = 3;
                damage = 8;
                range = 60;
                maxAmmoInMag = 7;
                ammoInMag = 0;
                // set the ammo sound
                normalClip = dEagleClip;
                // disabling other objects
                ak47Object.SetActive(false);
                dEagleObject.SetActive(true);
                // setting the mag info
                aIMTxt.text = ammoInMag.ToString();
                mAIMTxt.text = maxAmmoInMag.ToString();
                // destroying gun that i picked up
                Destroy(hit.transform.gameObject);
                // droping gun
                if (previousId != 0 && weaponId != previousId)
                {
                    Destroy(clone);
                    clone = Instantiate(ak47Object, gameObject.transform.position, transform.rotation, null);
                    clone.SetActive(true);
                    previousId = 2;
                }
                else
                {
                    previousId = 2;
                }
            }
            if (weaponId == 3)
            {
                Destroy(hit.transform.gameObject);
                ammo += hit.transform.GetComponent<IdOnItems>().ammo;
                ammoTxt.text = ammo.ToString();
            }
        }
    }
    IEnumerator ReloadingMethod()
    {
        isReloading = true;
        m_AudioSource.PlayOneShot(reloadingSound, 0.15f);
        yield return new WaitForSeconds(reloadingSound.length);
        isReloading = false;
        // Math for ammo
        if (ammo + ammoInMag <= maxAmmoInMag)
        {
            ammoInMag += ammo;
            ammo = 0;
            ammoTxt.text = ammo.ToString();
            aIMTxt.text = ammoInMag.ToString();
        }
        else
        {
            ammo -= maxAmmoInMag - ammoInMag;
            ammoInMag = maxAmmoInMag;
            ammoTxt.text = ammo.ToString();
            aIMTxt.text = ammoInMag.ToString();
        }
    }
    public void DiedMethodDrop()
    {
        if (ammo > 0)
        {
            clone = Instantiate(ammoObject,transform.position, transform.rotation, null);
            clone.GetComponent<IdOnItems>().ammo = ammo;
        }
        if(weaponId == 1)
        {
            Instantiate(ak47Object, transform.position, transform.rotation, null);
        }
        else if(weaponId == 2)
        {
            Instantiate(dEagleObject, transform.position,transform.rotation, null);
        }
        mAIMTxt.text = null;
        ammoTxt.text = null;
        aIMTxt.text = null;
        dash.text = null;
    }*/
}
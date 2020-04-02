using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Health : MonoBehaviour
{
    /*public float health = 50f;
    public float maxHealth = 50;
    public Slider slider;
    public bool died = false;
    public int avgFrameRate;
    public Text fps_Text;
    public bool isGood = true;
    public PostProcessVolume PPP;
    public GameObject body;
    void Start()
    {
        slider.maxValue = maxHealth;
        PPP.enabled = false;
    }
    private void Update()
    {
        //fps counter
        float current = Time.frameCount / Time.time;
        fps_Text.text = Mathf.Round(current).ToString() + " FPS";
        current = 0;
    }
    void FixedUpdate()
    {
        slider.value = health;
        if(isGood == false && health > 0)
        {
            health -= 5 * Time.fixedDeltaTime;
        }
    }
    //Damage
    public void TakeDamage(float amount)
    {
        health -= amount;
    }*/
}

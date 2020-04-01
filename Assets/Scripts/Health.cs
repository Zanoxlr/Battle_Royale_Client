using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50;
    public Slider slider;
    public bool isDead = false;
    void Start()
    {
        slider.maxValue = maxHealth; 
    }
    void Update()
    {
        slider.value = health;
    }
    //Damage
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        transform.rotation = Quaternion.EulerAngles(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        Debug.Log(transform.rotation);
    }
}

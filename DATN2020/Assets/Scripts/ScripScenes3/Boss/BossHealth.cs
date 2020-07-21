using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    //
    public int health = 500;
    // public GameObject deatheffect;


    // public bool isInvulnerable = false;  //dùng bất tử khi biến hình (chưa có)
    public void TakeDame(int Damage)
    {
        //dùng bất tử khi biến hình (chưa có)
        // if (isInvulnerable)
        //     return;
        health -= Damage;
        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {
       // Instantiate(deatheffect, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
    //
    public Slider slider;
    
    public void setMaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void sethealth(int health)
    {
        slider.value = health;
    }

}

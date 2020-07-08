using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Vector3 scale;
    public opposumwalker creep;
    public Gradient gradient;
    public Image fill;
    public void Start()
    {
        creep = GameObject.FindGameObjectWithTag("Enemy").GetComponent<opposumwalker>();

    }
    public void SetMaxHealth(int health)
    {
        scale = gameObject.transform.localScale;
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
       // ChangeDirection();
    }
    //kiểm tra hướng của thanh máu
    public void checkScale()
    {
        scale.x *= -1;
        transform.localScale = scale;
    }
    //public void ChangeDirection()
    //{
    //    Vector3 temp = transform.localScale;

    //    if (creep.faceright == false)
    //    {
    //        temp.x = 1f;
    //    }
    //    else
    //    {
    //        temp.x = -1f;
    //    }
    //    transform.localScale = temp;
    //}
        
}

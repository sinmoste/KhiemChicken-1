﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;


    private bool facingLeft = true;//kiểm tra trái (phải)
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    public Player player;
    //Máu và nổ khi chết 
    public HealthBar healthBar;
    public int maxHealth = 100;
    public Slider slider;


    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {

        //Transition from jump to fall
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        //Transition from Fall to idle
        if (coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }
        DeathFrog();//hủy object
    }

    private void Move()
    {

        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                   healthBar.checkScale();
                }
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                    healthBar.checkScale();
                }
                if (coll.IsTouchingLayers(ground))
                {
                    //jump

                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }
    void Damage(int damage)
    {

        maxHealth -= damage;
        healthBar.SetHealth(maxHealth);
    }
    void DeathFrog()
    {
        if (maxHealth <= 0)
        {
            anim.SetTrigger("DeathFrog");
        }
    }
    void Explosive()
    {
        Destroy(this.gameObject);
    }
    
    //knockback player
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.Damage(30); //mất 20 máu
            
            if (col.transform.position.x > transform.position.x)
            {
                player.Knockbackop(30f, player.transform.position, false);

            }
            else
            {
                player.Knockbackop(-30f, player.transform.position, true);
            }
        }
    }
    //Knockback screep
    public void Knockbackscreep()
    {
        Vector2 temp = gameObject.transform.position;
        if (player.faceright == true)
        {
            rb.AddForce(new Vector2(temp.x * 1f, temp.y));
        }
        else
        {
            rb.AddForce(new Vector2(temp.x * -1f, temp.y));//khi quay đầu
        }
    }
}

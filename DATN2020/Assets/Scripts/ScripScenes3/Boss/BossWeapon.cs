﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int AttackDame = 20;
    //cái này để biến hình mà chưa sài
    public int enrangeAttackdame = 40;
    //
    public Vector3 attackoffset;
    public float attackrange = 1f;

    public LayerMask attackmask;
    public void attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackoffset.x;
        pos += transform.up * attackoffset.y;

        Collider2D colinfo = Physics2D.OverlapCircle(pos, attackrange, attackmask);
        if (colinfo != null)
        {
            colinfo.GetComponent<Player>().Damage(AttackDame);
        }
    }
}

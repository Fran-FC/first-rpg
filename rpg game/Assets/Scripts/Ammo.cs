﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public int damageInflicted;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other is BoxCollider2D) {
            if(other.gameObject.CompareTag("Enemy")) {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                StartCoroutine(enemy.DamageCharacter(damageInflicted, 0.0f));
                gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int damageStrength;
    Coroutine damageCoroutine;

    private void OnEnable() {
        hitPoints = Instantiate(hitPoints);
        ResetCharacter();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Player player = other.gameObject.GetComponent<Player>();
            if(damageCoroutine == null ) {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            if(damageCoroutine != null){
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}

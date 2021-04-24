using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public HitPoints hitPoints;

    public virtual IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true){
            hitPoints.health -= damage;
            if(hitPoints.health <= 0)
            {
                hitPoints.health = 0;
                KillCharacter();
                break;
            }
            if(interval > 0.0f){
                yield return new WaitForSeconds(interval);
            } else {
                break;
            }
        }
    }

    public virtual void KillCharacter(){
        Destroy(gameObject);
    }

    public virtual void ResetCharacter() {
        hitPoints.health = hitPoints.initHealth;
    }
}

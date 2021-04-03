using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("CanBeCollected")){
            other.gameObject.SetActive(false);
        }
    }
}

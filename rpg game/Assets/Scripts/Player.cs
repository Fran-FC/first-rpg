using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Start() {
        hitPoints.health = hitPoints.initHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("CanBeCollected")){
            Item item = other.gameObject.GetComponent<Consumable>().item;
            if(item != null){
                bool shouldDisappear = false;
                switch (item.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = Inventory.instance.AddItem(item);
                        // update coin counter
                        break;    
                    case Item.ItemType.HEALTH:
                        if(hitPoints.health < hitPoints.maxHealth){
                            AdjustHitPoints(item.quantity);
                            shouldDisappear = true;
                        }
                        break;
                }
                if(shouldDisappear) other.gameObject.SetActive(false);
            }
        }
    }

    private void AdjustHitPoints(int quanity){
        int currentHealth = hitPoints.health + quanity;
        currentHealth = currentHealth > 100 ? 100 : currentHealth;
        hitPoints.health = currentHealth;
        Debug.Log("Health: " + hitPoints.health);
    }
}

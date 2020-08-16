using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The player that implements the {@link Character}.
/// </summary>
public class Player : Character
{
    public HealthBar healthBarPrefab;
    HealthBar healthBar;

/* tag can be picked up to compare */
    private const string CAN_BE_PICKED_UP = "CanBePickedUp";

    public void Start() {
        hitPoints.value = startingHitPoints;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    /// <summary>
    ///
    ///</summary>
    void OnTriggerEnter2D(Collider2D collison) {
        if(collison.gameObject.CompareTag(CAN_BE_PICKED_UP))
        {
            Item hitObject = collison.gameObject.GetComponent<Consumable>().item;

            if(hitObject != null)
            {
                bool shouldDisappear = false;

                switch(hitObject.itemType) {
                    case Item.ItemType.COIN:
                    shouldDisappear = true;
                    break;
                    case Item.ItemType.HEALTH:
                    shouldDisappear = AdjustHitPoints(hitObject.quantity);
                    break;
                    default:
                    break;
                }

                if(shouldDisappear) {
                    collison.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AdjustHitPoints(int amount) {
        if(hitPoints.value < maxHitPoints) {
            hitPoints.value = hitPoints.value + amount;
            
            print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints.value);

            return true;
        }
        
        return false;
    }
}

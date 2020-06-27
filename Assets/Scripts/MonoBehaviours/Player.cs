using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The player that implements the {@link Character}.
/// </summary>
public class Player : Character
{
    /* tag can be picked up to compare */
    private const string CAN_BE_PICKED_UP = "CanBePickedUp";

    /// <summary>
    ///
    ///</summary>
    void OnTriggerEnter2D(Collider2D collison) {
        if(collison.gameObject.CompareTag(CAN_BE_PICKED_UP))
        {
            Item hitObject = collison.gameObject.GetComponent<Consumable>().item;
            collison.gameObject.SetActive(false);

            if(hitObject != null)
            {
                print("Hit: " + hitObject.objectName);

                switch(hitObject.itemType) {
                    case Item.ItemType.COIN:
                    break;
                    case Item.ItemType.HEALTH:
                    AdjustHitPoints(hitObject.quantity);
                    break;
                    default:
                    break;
                }
                collison.gameObject.SetActive(false);
            }
        }
    }

    public void AdjustHitPoints(int amount) {
        hitPoints = hitPoints + amount;
        print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints);

    }
}

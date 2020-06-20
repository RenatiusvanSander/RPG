﻿using System.Collections;
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
            collison.gameObject.SetActive(false);
        }
    }
}

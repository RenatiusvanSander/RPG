using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Implementing Character classes use this Character class.
*/
public abstract class Character : MonoBehaviour
{
    
    /** hit points of a character */
    public HitPoints hitPoints;

    /** maximal hit points of a character */
    public float maxHitPoints;

    public float startingHitPoints;
}

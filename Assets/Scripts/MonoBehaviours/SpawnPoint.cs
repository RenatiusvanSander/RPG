using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpwan;

    public float repeatInterval;

    public void Start() {
        if(repeatInterval > 0) {
            InvokeRepeating("SpwanObject", 0.0f, repeatInterval);
        }
    }

    public GameObject SpawnObject() {
        if(prefabToSpwan != null) {
            return Instantiate(prefabToSpwan, transform.position, Quaternion.identity);
        }

        return null;
    }
}

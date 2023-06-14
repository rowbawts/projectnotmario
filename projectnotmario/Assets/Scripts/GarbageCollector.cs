using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    public GameObject objectToDestroy;
    
    private void OnBecameInvisible()
    {
        // Destroy the game object when it becomes invisible to any camera
        Destroy(objectToDestroy);
    }
}

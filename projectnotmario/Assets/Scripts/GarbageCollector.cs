using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Destroy the game object when it becomes invisible to any camera
        Destroy(transform.parent.gameObject);
    }
}

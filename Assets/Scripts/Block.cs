using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    public delegate void BlockEventHandler();
    public static event BlockEventHandler BlockDestroyed; // Event to notify when a block is destroyed

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
            BlockDestroyed?.Invoke(); // Invoke the BlockDestroyed event
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    
    public float onscreanDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onscreanDelay);
    }

    // Update is called once per frame
   
}

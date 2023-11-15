using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaur : MonoBehaviour
{
    public PlayerManager playerManager ; 
       
    void Start()
    {
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

      
   void OnCollisionEnter(Collision collision)
 {
     if (collision.gameObject.name == "Player")
 {
  Debug.Log("Item collected!");
 Destroy(this.transform.gameObject);

 
 playerManager.Items += 1;
 }
}
}

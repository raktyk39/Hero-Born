using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavare : MonoBehaviour
{
    public Vector3 compOffpofSet  = new Vector3 (0f,1.2f , - 2.5f ); 

    public Transform target ;


    void Start()
    {
        
       target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
  public  void LateUpdate()
    {
        

        this.transform.position = target.TransformPoint(compOffpofSet); // Transform  позволяет переместить ее в другое место или повернуть относительно какой-то точки. TransformPoint позволяет вам вычислить новые координаты этой точки после такого преобразования.
        this.transform.LookAt(target);
    }
}

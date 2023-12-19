using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed = 10f;
    public float rotatespeed = 75f;
    public float speed = 5f;
    public float bulletspeed = 1000f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    private float vlnput;
    private PlayerManager _gameManager;
    private float hlnput;
    private Rigidbody rb ;
    private CapsuleCollider _col;
   
    public void Start ()
    {
        rb = GetComponent <Rigidbody>();
        _col = GetComponent< CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }


    void FixedUpdate()
    {
            vlnput = Input.GetAxis("Vertical") * movespeed;
            hlnput = Input.GetAxis("Horizontal") * rotatespeed;

            Vector3  rotation = Vector3.up * hlnput;
            Quaternion angelDot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

            rb.MovePosition( this.transform.position + this.transform.forward * vlnput * speed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * angelDot);
            // this.transform.Translate(Vector3.forward * vlnput * Time.deltaTime);
            // this.transform.Rotate(Vector3.up * hlnput * Time.deltaTime);
            
        if ( IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVelocity,ForceMode.Impulse );
        }   
        
        if ( Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate( bullet, this.transform.position + new Vector3 (1,0,0 ), this.transform.rotation) as GameObject;// А не префабом а игровым обьектом

            Rigidbody bulletrb = Bullet.GetComponent<Rigidbody>();

            bulletrb.velocity = this.transform.forward * bulletspeed;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.
        center, capsuleBottom, distanceToGround, groundLayer,
        QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemi gonna Atack");
            _gameManager.HP -=1;        
        }
    }
}

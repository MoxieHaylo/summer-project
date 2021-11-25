using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement Speeds")]
    public  float       walkSpeed = 3f;
    public  float       jumpSpeed = 5f; //add variance for up vs down at some point
    public  bool        isMoving;
    private Vector3     prevPos;
    private Vector3     jump;

    public  bool        isGrounded = false;

    private Rigidbody   rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f,2f,0f);
    }

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }

        float xDirection = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);
        transform.position += moveDirection * walkSpeed * Time.deltaTime;

        //if(prevPos==transform.position)
        //{
        //    Debug.Log("shit is moving");
        //}
        //prevPos = transform.position;

        if (transform.hasChanged)
        {
            isMoving = true;
            transform.hasChanged = false;
        }
        else
        {
            isMoving = false;
        }

    }

    private void FixedUpdate()
    {

    }
}

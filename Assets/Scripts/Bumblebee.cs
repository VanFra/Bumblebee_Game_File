using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bumblebee : MonoBehaviour
{
 [SerializeField] private float _speed = 12f;

 [SerializeField] private UImanager _uImanager;

 
 Rigidbody m_Rigidbody;
 //private float _jumpTimer = -1f;
 //private float _jumpRate = 0.3f;

 public Vector3 jump;
 public float jumpForce = 1.0f;
 public bool isGrounded;
 private AudioSource _buzzing;


 // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-135f, 7f, -1.68f);
        // From the Unity Documentation
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        //Stop the Rigidbody from rotating
        m_Rigidbody.freezeRotation = true;
        jump = new Vector3(0.0f,12.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Jump();
        Buzzing();

    }

    public void RelayScore(int score)
    {
        _uImanager.AddScore(score);
        //_uImanager.ShowMessage();
        
    }



    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            m_Rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }



    void Buzzing()
        {
            if (isGrounded == false)
            {
                _buzzing = GetComponent<AudioSource>();
                _buzzing.volume = 0.3f;
                _buzzing.pitch = 1.3f;
            }
            else
            {
                _buzzing.volume = 0.1f;
                _buzzing.pitch = 1.1f;
            }

        }
    
    void PlayerMovement()
    {

            float horizontalInput = Input.GetAxis("Horizontal");
            float frontBackInput = Input.GetAxis("Vertical");
            float RotateSpeed = 56f;

            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed * frontBackInput);

          
                if (Input.GetKey(KeyCode.A))
                {  
                    transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
                }
            

       //     if (transform.position.x < -145f)
       //     {
       //         transform.position = new Vector3(-145f, transform.position.y, transform.position.z);
       //     }
            
       //     if (transform.position.x > 23f)
       //     {
       //         transform.position = new Vector3(23f, transform.position.y, transform.position.z);
       //     }

       //     if (transform.position.z < -62f)
       //     {
       //         transform.position = new Vector3( transform.position.x, transform.position.y, -62f);

       //   }
            
       //   if (transform.position.z > 62)
       //   {
       //       transform.position = new Vector3( transform.position.x, transform.position.y, 62f);

       //   }










    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class Bumblebee : MonoBehaviour
{
 [SerializeField] private float _speed = 12f;

 [SerializeField] private UImanager _uImanager;

 
 Rigidbody m_Rigidbody;


 public Vector3 jump;
 public float jumpForce = 1.0f;
 public bool isGrounded;
 
 private AudioSource _buzzing;


 // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-117f, 19.5f, -2.26f);
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
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void RelayScore(int score)
    {
        _uImanager.AddScore(score);
    }

    public void RelayCount(int count)
    {
        _uImanager.AddCount(count);
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
                _buzzing.volume = 0.8f;
                _buzzing.pitch = 1.3f;
            }
            else
            {
                _buzzing.volume = 0.5f;
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

                
                if (transform.position.x < -165.9f)
                { 
                    transform.position = new Vector3(-165.9f, transform.position.y, transform.position.z);
                }
            
               if (transform.position.x > 672.4179f)
               { 
                   transform.position = new Vector3(672.4179f, transform.position.y, transform.position.z);
               }

              if (transform.position.z < -590.6694f)
              {
                  transform.position = new Vector3( transform.position.x, transform.position.y, -590.6694f);
              }
            
              if (transform.position.z > 544.9294f)
              {
                  transform.position = new Vector3(transform.position.x, transform.position.y, 544.9294f);
              }
              
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hive")
        {
            SceneManager.LoadScene("Endscreen");

        }

    }

}

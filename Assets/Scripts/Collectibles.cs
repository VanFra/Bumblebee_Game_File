using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0f, 1f, 0f, Space.Self);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            GameObject.FindWithTag("Player").GetComponent<Bumblebee>().RelayCount(1);
            Destroy(this.gameObject);
        }

    }

}
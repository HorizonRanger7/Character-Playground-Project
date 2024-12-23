using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    //Variables

    //Using player movement here.
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set what happens when you hit another object, depending on the tag.
    private void OnCollisionEnter(Collision collision)
    {

    //This code checks if we are on the ground. 
        if (collision.transform.tag == "Ground")
        {
            playerMovement.grounded = true;
        }

    }

}

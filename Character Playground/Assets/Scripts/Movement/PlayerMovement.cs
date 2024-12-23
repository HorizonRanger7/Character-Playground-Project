using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables

    [SerializeField] float playerSpeed = 1f;
    [Tooltip("How fast the player moves. It's a float, cause changing it by a whole number increases the speed drastically.")]

    [SerializeField] float jumpForce = 10f;
    [Tooltip("How high the player jumps.")]

    bool grounded = true;

    private Rigidbody rb;

    public AudioSource audioSource;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //This code makes it so that pressing W moves the player forward.
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();

        }

        //This code makes it so that pressing A moves the player left.
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();

        }

        //This code makes it so that pressing S moves the player backwards.
        if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
            
        }

        //This code makes it so that pressing D moves the player backwards.
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
            
        }

    }



    //Various methods for moving. Can be applied to an if statement with Input.GetKey.

    void MoveForward()
    {
        transform.position += Vector3.forward * playerSpeed * Time.deltaTime;

    }

     
    void MoveLeft()
    {
        transform.position += Vector3.left * playerSpeed * Time.deltaTime;

    }

    void MoveRight()
    {
        transform.position += Vector3.right * playerSpeed * Time.deltaTime;
    }

    void MoveBack()
    {
        transform.position += Vector3.back * playerSpeed * Time.deltaTime;

    }


    //Code for jumping. Status: Unused.
     private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        grounded = false;

    }

    private void Dash()
    {
        //err idk might do this later

    }






}

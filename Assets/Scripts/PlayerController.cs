using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce; // force player jump
    bool canJump; // can player jump?
    public float gravity;
    Vector3 moveVector = Vector3.zero;

    // called when start a game
    private void Awake()
    {
        rb= GetComponent<Rigidbody>(); //rigidbody which we attached to a gameObject,
                                       //it's a reference inside in variable rb (add gravity, velocity by using rb)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // we need to check touching on our screen
        if (Input.GetMouseButton(0) && canJump) // left mouse button AND we can jump?
        {
            // Jump when we press\touch
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // called when rb touch another collision
        if (collision.gameObject.tag == "Ground")
        { 
        
            canJump= true;
        
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // if player in the air, he can't jump anymore
        if (collision.gameObject.tag == "Ground")
        {

            canJump = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if we colliding with enemy or not
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Scene0"); // when we touch obstacle, scene reloaded
        }
    }
}

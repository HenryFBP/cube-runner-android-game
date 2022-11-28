using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    //called before first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMouseClicked = Input.GetMouseButtonDown(0);
        bool isSpacePressed = Input.GetKeyDown("space");
        bool isUpPressed = Input.GetKeyDown("up");
        if (isMouseClicked||isSpacePressed||isUpPressed)
        {
            if (this.canJump)
            {
                //jump
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                this.canJump = false;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.canJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //reload when we touch obstacle
            SceneManager.LoadScene("SceneGame");
        }
    }
}

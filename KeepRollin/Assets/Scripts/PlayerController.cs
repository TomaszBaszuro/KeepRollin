using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float jumpForce;
    bool canJump;
    bool playerOnRightGround = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(100 * Time.deltaTime, 0f, 0f, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            
            SceneManager.LoadScene("Menu");
        }
    }

    public void PlayerJump()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void MoveLeft()
    {
        if (playerOnRightGround && canJump)
        {
            transform.position = new Vector3(-4, 6, 2);
            playerOnRightGround = false;
        }

    }
    public void MoveRight()
    {
        if (!playerOnRightGround && canJump)
        {
            transform.position = new Vector3(0, 2, 0);
            playerOnRightGround = true;
        }
    }
}
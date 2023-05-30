using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    //Vector3 leftRotation = new Vector3(0f, 0f, 90f);
    //Vector3 rightRotation = new Vector3(0f, 0f, -90f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void RotateLeft()
    {
        //Vector3 rotationToAdd = new Vector3(0, 0, 90);
        //transform.Rotate(rotationToAdd);
        
        //Quaternion newRotation = Quaternion.Euler(0, 0, 90);
    }

    public void RotateRight()
    {
        /*transform.eulerAngles += rightRotation*/;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

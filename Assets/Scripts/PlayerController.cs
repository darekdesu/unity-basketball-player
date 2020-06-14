using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalInput;
    public float verticalInput;

    GameObject ballInHand;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.left * verticalInput * Time.deltaTime * speed);

        if (ballInHand != null)
        {
            ballInHand.transform.parent = gameObject.transform;
            ballInHand.transform.localPosition = new Vector3(0, 0, 1.2f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision enter: " + other.gameObject.name);

        if (other.gameObject.CompareTag("BallTag"))
            ballInHand = other.gameObject;
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Collision exit: " + other.gameObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;
    public int speed = 8;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputHorizontal);
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 targetPosition = new Vector3(inputHorizontal, 0, inputVertical);
       
        rb.velocity = (targetPosition * speed);
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 320 * Time.deltaTime);
        }
    }
}

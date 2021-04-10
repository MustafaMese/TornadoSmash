using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float deltaThreshold;
    [SerializeField] float sensitivity;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;

    private Vector3 firstPosition;
    private Vector3 currentTouchPosition;
    private Rigidbody rb;
    private float finalX;
    private float finalZ;
    
    private void Start() 
    {
        rb = GetComponent<Rigidbody>();    
        ResetValues();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.canStart)
            HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            currentTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (currentTouchPosition - firstPosition);

            if (firstPosition == currentTouchPosition)
            {
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            }

            finalX = transform.position.x;
            finalZ = transform.position.z;

            if (Mathf.Abs(touchDelta.x) >= deltaThreshold)
            {
                finalX = (transform.position.x + (touchDelta.y * -sensitivity));
            }
            if (Mathf.Abs(touchDelta.y) >= deltaThreshold)
            {
                finalZ = (transform.position.z + (touchDelta.x * sensitivity));
            }

            rb.position = new Vector3(finalX, transform.position.y, finalZ);
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minX, maxX), rb.position.y, Mathf.Clamp(rb.position.z, minZ, maxZ));

            firstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetValues();
        }
    }

    private void ResetValues()
    {
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        firstPosition = Vector2.zero;
        finalX = 0f;
        finalZ = 0f;
        currentTouchPosition = Vector2.zero;
    }
}

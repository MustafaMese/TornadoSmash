using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] float speed = 20;
    [SerializeField] float shiftSpeed = 5;
    [SerializeField] Transform tornado;
    [SerializeField] Transform target;

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (GameManager.Instance.canStart)
            tornado.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rbPLayer;
    [SerializeField] float playerSpeed;


    private void Awake()
    {

        rbPLayer = GetComponent<Rigidbody2D>();

    }


    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        rbPLayer.linearVelocity = Vector2.right * xAxis * playerSpeed;
    }










}

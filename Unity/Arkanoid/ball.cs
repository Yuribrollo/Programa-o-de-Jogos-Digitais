using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D rbBall;
    [SerializeField] float ballSpeed;

    private void Awake()
    {

        rbBall = GetComponent<Rigidbody2D>();

    }

    public void StartBall()
    {
        rbBall.linearVelocity = Vector2.up * ballSpeed;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            float xAxis = transform.position.x - collision.transform.position.x / collision.collider.bounds.size.x;
            Vector2 direction = new Vector2(xAxis, 3).normalized;

            rbBall.linearVelocity = direction * ballSpeed;

        }
    }


}

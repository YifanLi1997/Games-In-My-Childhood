using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float horizontalMovementSpeed = 0.1f;
    [SerializeField] float verticalBounceForce = 300f;

    ScoreSystem m_scoreSystem;
    Rigidbody2D m_rigidbody2D;
    GameObject m_currentCloud;

    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    void Update()
    {
        KeyboardControl();
        //AccelerometerControl();
    }

    private void AccelerometerControl()
    {
        transform.Translate(Input.acceleration.x, 0, 0);
    }

    private void KeyboardControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-horizontalMovementSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(horizontalMovementSpeed, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            ResetVerticalVelocity();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, verticalBounceForce)); // bounce the player

            if (m_currentCloud != collision.gameObject)
            {
                m_currentCloud = collision.gameObject;
                m_scoreSystem.AddScore();
            }
        }
    }

    private void ResetVerticalVelocity()
    {
        Vector2 currentVelocity = m_rigidbody2D.velocity;
        m_rigidbody2D.velocity = new Vector2(currentVelocity.x, 0f);
    }
}

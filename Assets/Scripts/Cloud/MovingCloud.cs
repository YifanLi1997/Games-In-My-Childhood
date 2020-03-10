using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    [SerializeField] Vector2 startVelocity = new Vector2(0.5f, -1f);

    Rigidbody2D m_rigidbody2D;
    Vector2 m_currentVelocity;

    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.velocity = startVelocity;
        m_currentVelocity = m_rigidbody2D.velocity;
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            m_rigidbody2D.velocity = new Vector2(-m_currentVelocity.x, m_currentVelocity.y);
            m_currentVelocity = m_rigidbody2D.velocity;
        }
    }
}

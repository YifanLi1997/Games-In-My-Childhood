using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    [SerializeField] Vector2 startVelocity = new Vector2(0.5f, -1f);

    Rigidbody2D m_rigidbody2D;

    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.velocity = startVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            var currentVelocity = m_rigidbody2D.velocity;
            m_rigidbody2D.velocity = new Vector2(-currentVelocity.x, currentVelocity.y);
        }
    }
}

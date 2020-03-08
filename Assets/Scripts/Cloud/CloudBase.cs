using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBase : MonoBehaviour
{
    [SerializeField] float verticalSpeed = -1f;


    Rigidbody2D m_rigidbody2D;

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        m_rigidbody2D.velocity = new Vector2(0f, verticalSpeed);
    }
}

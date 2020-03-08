using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] Vector2 scrollingOffset = new Vector2(0.1f, 0.03f);

    private void Awake()
    {
        if (FindObjectsOfType<ScrollingBackground>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset += scrollingOffset;
    }

}

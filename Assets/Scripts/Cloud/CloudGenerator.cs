using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject cloudPrefab;
    [SerializeField] GameObject movingCloudPrefab;

    [Header("Generation Configs")]
    [SerializeField] float generationGap = 4f;
    [SerializeField] float generationPosY = 8f;

    bool m_isGenerating = true;
    float m_gapCount;
    float m_generationSeed;
    GameObject m_newestCloud;

    void Start()
    {
        m_gapCount = generationGap;
        GenerateCloud();
    }

    private void Update()
    {
        m_gapCount -= Time.deltaTime;

        if (m_gapCount <= 0 && m_isGenerating)
        {
            GenerateCloud();
            m_gapCount = generationGap;
        }
    }

    private void GenerateCloud()
    {
        m_generationSeed = UnityEngine.Random.Range(0f, 1f);

        Vector3 generationPos = new Vector3(UnityEngine.Random.Range(-2.7f, 2.7f), generationPosY);
        if (m_generationSeed < 0.2f)
        {
            m_newestCloud = Instantiate(
                movingCloudPrefab, generationPos, Quaternion.identity) as GameObject;
        }
        else
        {
            m_newestCloud = Instantiate(
                cloudPrefab, generationPos, Quaternion.identity) as GameObject;
        }
        m_newestCloud.transform.parent = gameObject.transform;
    }
}

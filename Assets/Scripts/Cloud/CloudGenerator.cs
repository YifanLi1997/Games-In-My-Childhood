using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject cloudPrefab;
    [SerializeField] float generationGap = 4f;
    [SerializeField] float generationPosY = 8f;

    bool isGenerating = true;
    float gapCount;

    void Start()
    {
        gapCount = generationGap;
        GenerateCloud();
    }

    private void Update()
    {
        gapCount -= Time.deltaTime;

        if (gapCount <= 0 && isGenerating)
        {
            GenerateCloud();
            gapCount = generationGap;
        }
    }

    private void GenerateCloud()
    {
        Vector3 generationPos = new Vector3(UnityEngine.Random.Range(-2.7f, 2.7f), generationPosY);
        GameObject newCloud = Instantiate(
            cloudPrefab, generationPos, Quaternion.identity) as GameObject;
        newCloud.transform.parent = gameObject.transform;
    }
}

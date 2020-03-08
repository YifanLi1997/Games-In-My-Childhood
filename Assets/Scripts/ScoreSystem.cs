using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int m_score = 0;

    private void Start()
    {
        SetText();
    }

    private void SetText()
    {
        scoreText.text = m_score.ToString();
    }

    public int GetScore()
    {
        return m_score;
    }

    public void AddScore()
    {
        m_score++;
        SetText();
    }
}

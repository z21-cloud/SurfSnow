using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

namespace SnowSurfer.Helper
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int currentScore = 0;

        private void Awake()
        {

        }

        private void OnEnable()
        {
            FlipsCounter.flip += IncreaseScore;
        }

        private void IncreaseScore()
        {
            currentScore++;
            Debug.Log(currentScore);
            scoreText.text = (currentScore * 100).ToString();
        }

        private void OnDisable()
        {
            FlipsCounter.flip -= IncreaseScore;
        }
    }
}


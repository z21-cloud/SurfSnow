using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SnowSurfer.Core
{
    public class CharSelectManager : MonoBehaviour
    {
        [SerializeField] private GameObject scoreCanvas;
        [SerializeField] private GameObject dinoSprite;
        [SerializeField] private GameObject frogSprite;
        private void Start()
        {
            Time.timeScale = 0f;
        }

        private void BeginGame()
        {
            Time.timeScale = 1f;
            scoreCanvas.SetActive(true);
            gameObject.SetActive(false);
        }

        public void ChooseDino()
        {
            dinoSprite.SetActive(true);
            BeginGame();
        }

        public void ChooseFrog()
        {
            frogSprite.SetActive(true);
            BeginGame();
        }
    }
}


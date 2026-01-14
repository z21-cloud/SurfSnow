using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SnowSurfer.Core;

namespace SnowSurfer.Helper
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private float delayBetweenLevels = 1f;
        public static LevelManager Instance { get; private set; }
        public int CurrentScene => SceneManager.GetActiveScene().buildIndex;

        private bool isLoading = false;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            PlayersHeadCollision.LossAction -= RestartLevel;
            PlayersHeadCollision.LossAction += RestartLevel;
            PlayerWins.PlayerFinishesLevel -= LoadNextLevel;
            PlayerWins.PlayerFinishesLevel += LoadNextLevel;
        }

        //Loading next
        private void LoadNextLevel()
        {
            if (isLoading) return;
            StartCoroutine(LoadNextAfterDelay());
        }

        private IEnumerator LoadNextAfterDelay()
        {
            isLoading = true;
            yield return new WaitForSeconds(delayBetweenLevels);
            SceneManager.LoadScene(CurrentScene + 1);
            isLoading = false;
        }

        //Restarting current Level
        private void RestartLevel()
        {
            if (isLoading) return;
            StartCoroutine(RestartAfterDelay());
        }

        private IEnumerator RestartAfterDelay()
        {
            isLoading = true;
            yield return new WaitForSeconds(delayBetweenLevels);
            Debug.LogWarning("Перезагрузка сцены");
            SceneManager.LoadScene(CurrentScene);
            isLoading = false;
        }

        public void RestartGame()
        {
            isLoading = true;
            SceneManager.LoadScene(0);
            isLoading = false;
        }

        private void OnDisable()
        {
            PlayersHeadCollision.LossAction -= RestartLevel;
            PlayerWins.PlayerFinishesLevel -= LoadNextLevel;
        }
    }
}

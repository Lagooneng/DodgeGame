using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lagooneng.DodgeGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private GameObject gameEnd;
        [SerializeField] private TMP_Text score;

        private void Awake()
        {
            Instance = this;
        }

        public void GameEnd()
        {
            gameEnd.SetActive(true);
            score.text = "Candy: " + ((int)PlayTime.Instance.LastPlayTime / 10 + 1).ToString();
        }

        public void ReLoadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}



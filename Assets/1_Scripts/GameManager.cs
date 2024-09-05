using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lagooneng.DodgeGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public bool GameEnded { get; set; }
        [SerializeField] private GameObject gameEnd;
        [SerializeField] private TMP_Text score;

        private void Awake()
        {
            Instance = this;
            Time.timeScale = 0.0f;
            GameEnded = false;
        }

        private void Update()
        {
            if( Input.GetKeyDown(KeyCode.Space) && Time.timeScale < 1.0f )
            {
                if( GameEnded )
                {
                    ReLoadScene();
                }
                else
                {
                    GameManager.Instance.ActiveTime();
                    CountDown.Instance.GameEndCalled();
                }
                
            }
        }

        public void GameEnd()
        {
            GameEnded = true;
            gameEnd.SetActive(true);
            score.text = "Candy: " + ((int)PlayTime.Instance.LastPlayTime / 10 + 1).ToString();
        }

        public void ActiveTime()
        {
            Time.timeScale = 1.0f;
        }

        public void ReLoadScene()
        {
            Time.timeScale = 0.0f;
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



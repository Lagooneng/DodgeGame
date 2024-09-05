using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Lagooneng.DodgeGame
{
    public class PlayTime : MonoBehaviour
    {
        public static PlayTime Instance;
        [SerializeField] TMP_Text text;
        public float LastPlayTime { get; set; }
        private float sceneLoadTime;

        private void Awake()
        {
            Instance = this;
            sceneLoadTime = Time.time;  // 씬이 로드된 시간 저장
        }

        private void Update()
        {
            // 씬이 로드된 이후의 시간을 계산
            LastPlayTime = Time.time - sceneLoadTime - 3.0f;
            if( LastPlayTime > 0.0f )
            {
                text.text = "Time: " + LastPlayTime.ToString("F2");
            }
            else
            {
                text.text = "Time: " + "00.00";
            }
            
        }
    }
}

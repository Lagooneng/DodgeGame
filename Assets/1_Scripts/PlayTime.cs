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

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            LastPlayTime = Time.time;
            text.text = "Time: " + Time.time.ToString("F2");
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lagooneng.DodgeGame
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private GameObject StartGroup;
        [SerializeField] private GameObject StartBtn;
        [SerializeField] int count = 3;
        [SerializeField] private TMP_Text countText;

        public void GameEndCalled()
        {
            StartBtn.SetActive(false);
            countText.enabled = true;

            StartCoroutine(Count());
        }

        public IEnumerator Count()
        {
            for( int i = 0; i < count; ++i )
            {
                countText.text = (count - i).ToString();

                yield return new WaitForSeconds(1.0f);
            }

            StartGroup.SetActive(false);
        }
    }
}



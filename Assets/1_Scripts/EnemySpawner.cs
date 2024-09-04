using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lagooneng.DodgeGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyList;
        [SerializeField] private Transform leftNCeiling;
        [SerializeField] private Transform rightNBottom;
        [SerializeField] private bool isHorizontal = true;
        [SerializeField] private float spawnMinDelay = 0.2f;
        [SerializeField] private float spawnMaxDelay = 2.0f;
        private float spawnDelay = 0.1f;
        private int enemyLength;

        private void Awake()
        {
            enemyLength = enemyList.Length;

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            int idx = -1;
            Vector3 pos = Vector3.zero;
            while ( true )
            {
                idx = Random.Range(0, enemyLength);
                
                if (isHorizontal)
                {
                    pos = new Vector3(Random.Range(leftNCeiling.position.x, rightNBottom.position.x),
                                            leftNCeiling.position.y, 0.0f);
                }
                else
                {
                    pos = new Vector3(leftNCeiling.position.x,
                                            Random.Range(leftNCeiling.position.y, rightNBottom.position.y), 0.0f);
                }

                Instantiate(enemyList[idx], pos, Quaternion.identity);

                spawnDelay = Random.Range(spawnMinDelay, spawnMaxDelay);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}



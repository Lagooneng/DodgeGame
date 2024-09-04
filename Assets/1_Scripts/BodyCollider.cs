using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lagooneng.DodgeGame
{
    public class BodyCollider : MonoBehaviour
    {
        private Player player;

        private void Start()
        {
            player = Player.Instance;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if( collision.CompareTag("Enemy") )
            {
                player.GameEnd();
            } 
        }
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using SnowSurfer.Helper;
using System;

namespace SnowSurfer.Core
{
    public class PlayerWins : MonoBehaviour
    {
        public static event Action PlayerFinishesLevel;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Win>())
            {
                PlayerFinishesLevel?.Invoke();
            }
        }
    }
}


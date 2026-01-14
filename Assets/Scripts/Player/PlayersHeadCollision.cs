using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using SnowSurfer.Helper;

namespace SnowSurfer.Core
{
    public class PlayersHeadCollision : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        public static event Action LossAction;

        private BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();

            if (boxCollider2D == null)
                Debug.LogError("BoxCollider2D не найден");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //(1 << collision.gameObject.layer) сдвиг числа на layer позиций => превратили номер словя в LayerMask;
            //& groundLayer) != 0) - если биты совпадают => вернет 1, что означает, что касаемся нужного слоя
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                LossAction?.Invoke();
            }
        }
    }
}
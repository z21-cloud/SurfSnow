using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SnowSurfer.Helper;
using Unity.VisualScripting;
using System;

namespace SnowSurfer.Core
{
    public class PowerupManager : MonoBehaviour
    {
        [SerializeField] private PowerupSO powerup;

        private SpriteRenderer spriteRenderer; // заменить на object pooling
        private float timeLeft;

        public static event Action<PowerupSO> OnActivatePowerup;
        public static event Action OnActivatePowerupEffect;
        public static event Action<PowerupSO> OnDeactivatePowerup;
        public static event Action OnDeactivatePowerupEffect;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            timeLeft = powerup.GetPowerupTime();
        }

        private void Update()
        {
            CountdownTimer();
        }

        private void CountdownTimer()
        {
            if (timeLeft > 0 && !spriteRenderer.enabled)
            {
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    OnDeactivatePowerup?.Invoke(powerup);
                    OnDeactivatePowerupEffect?.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject == PlayerLocator.Player && spriteRenderer.enabled)
            {
                spriteRenderer.enabled = false;
                OnActivatePowerup?.Invoke(powerup);
                OnActivatePowerupEffect?.Invoke();
            }
        }
    }
}


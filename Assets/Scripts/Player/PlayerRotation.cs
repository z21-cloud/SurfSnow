using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SnowSurfer.Helper;

namespace SnowSurfer.Core
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float baseSpeed = 15f;
        [SerializeField] private float boostSpeed = 20f;

        public bool isAlive { get; private set; } = true;

        private Rigidbody2D rb;
        private SurfaceEffector2D surfaceEffector2D;
        
        private void OnEnable()
        {
            PlayersHeadCollision.LossAction += Death;
            PowerupManager.OnActivatePowerup += ActivatePowerup;
            PowerupManager.OnDeactivatePowerup += DeactivatePowerup;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
            if (rb == null)
            {
                Debug.LogError("RigidBody2D is null!");
            }
        }

        private void Update()
        {
            if(!isAlive) return;

            Vector2 input = InputManager.Instance.GetInput();
            bool boost = InputManager.Instance.Boost();

            if (input != null) RotatePlayer(input);
            BoostPlayer(boost);
        }

        private void RotatePlayer(Vector2 input)
        {
            Debug.Log(input.x);
            rb.AddTorque(rotationSpeed * (-input.x)); //minus, because i want to player rotates to left if he hits left and right if he hits right. Without minus I've got opposite direction
        }

        private void BoostPlayer(bool boost)
        {
            surfaceEffector2D.speed = boost ? boostSpeed : baseSpeed;
        }

        private void ActivatePowerup(PowerupSO powerup)
        {
             if(powerup.GetPowerupType() == "speed")
            {
                baseSpeed += powerup.GetPowerupValue();
                boostSpeed += powerup.GetPowerupValue();
            }
            else if(powerup.GetPowerupType() == "torque")
            {
                rotationSpeed += powerup.GetPowerupValue();
            }
        }

        private void DeactivatePowerup(PowerupSO powerup)
        {
            if (powerup.GetPowerupType() == "speed")
            {
                baseSpeed -= powerup.GetPowerupValue();
                boostSpeed -= powerup.GetPowerupValue();
            }
            else if (powerup.GetPowerupType() == "torque")
            {
                rotationSpeed -= powerup.GetPowerupValue();
            }
        }

        private void Death()
        {
            isAlive = false;
        }

        private void OnDisable()
        {
            PlayersHeadCollision.LossAction -= Death;
            PowerupManager.OnActivatePowerup -= ActivatePowerup;
            PowerupManager.OnDeactivatePowerup -= DeactivatePowerup;
        }
    }
}

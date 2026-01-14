using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SnowSurfer.Core;
using SnowSurfer.Helper;
using System;

namespace SnowSurfer.Helper
{
    public class SnowTrail : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private ParticleSystem snowTrail;

        [Header("Colors")]
        [SerializeField] private Color normalColor = Color.white;
        [SerializeField] private Color boostColorA = new Color(1f, 0.5f, 0f);
        [SerializeField] private Color boostColorB = Color.red;

        private void OnEnable()
        {
            PowerupManager.OnActivatePowerupEffect += ActivatePowerupEffect;
            PowerupManager.OnDeactivatePowerupEffect += DeactivatePowerupEffect;
        }

        private void ActivatePowerupEffect()
        {
            var main = snowTrail.main;
            Debug.Log("Boost enable");
            main.startColor = new ParticleSystem.MinMaxGradient(boostColorA, boostColorB);
        }

        private void DeactivatePowerupEffect()
        {
            var main = snowTrail.main;
            Debug.Log("Boost disabled");
            main.startColor = new ParticleSystem.MinMaxGradient(normalColor);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                snowTrail.Play();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                snowTrail.Stop();
            }
        }

        private void OnDisable()
        {
            PowerupManager.OnActivatePowerupEffect -= ActivatePowerupEffect;
            PowerupManager.OnDeactivatePowerupEffect -= DeactivatePowerupEffect;
        }
    }
}

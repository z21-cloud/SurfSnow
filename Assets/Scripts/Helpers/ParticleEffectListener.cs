using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SnowSurfer.Core;

namespace SnowSurfer.Helper
{
    public enum EffectType
    {
        Loss,
        Win
    }

    public class ParticleEffectListener : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private EffectType effectType;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            switch(effectType)
            {
                case EffectType.Loss:
                    PlayersHeadCollision.LossAction += Play;
                    break;

                case EffectType.Win:
                    PlayerWins.PlayerFinishesLevel += Play;
                    break;
            }
        }

        private void Unsubscribe()
        {
            switch (effectType)
            {
                case EffectType.Loss:
                    PlayersHeadCollision.LossAction -= Play;
                    break;

                case EffectType.Win:
                    PlayerWins.PlayerFinishesLevel -= Play;
                    break;
            }
        }

        private void Play()
        {
            particle.Play();
        }
    }
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SnowSurfer.Helper
{
    public class FlipsCounter : MonoBehaviour
    {
        [SerializeField] private int fullCircle = 340; // angle player need to rotate to count flip

        private float previousRotation;
        private float totalRotation;

        public static event Action flip;

        private void Update()
        {
            FlipCount();
        }

        private void FlipCount()
        {
            float currentRotation = transform.rotation.eulerAngles.z;
            totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

            if (totalRotation > fullCircle || totalRotation < -fullCircle)
            {
                flip?.Invoke();
                totalRotation = 0;
            }

            previousRotation = currentRotation;
        }
    }
}


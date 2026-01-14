using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SnowSurfer.Helper
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public Vector2 GetInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            return new Vector2(x, y);
        }

        public bool Boost() => Input.GetKey(KeyCode.E);
    }
}


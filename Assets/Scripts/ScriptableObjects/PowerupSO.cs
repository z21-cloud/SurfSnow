using UnityEngine;

namespace SnowSurfer.Helper
{
    [CreateAssetMenu(fileName = "Powerup", menuName = "Scriptable Objects/PowerupSO")]
    public class PowerupSO : ScriptableObject
    {
        [SerializeField] private string powerType;
        [SerializeField] private float valueChange;
        [SerializeField] private float time;

        public string GetPowerupType() => powerType;
        public float GetPowerupValue() => valueChange;
        public float GetPowerupTime() => time;
    }
}


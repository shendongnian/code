    using System;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class CycleBar : MonoBehaviour
    {
        [SerializeField]
        private Image cycleBar;
    
        private TimeMod currentMod = TimeMod.AM;
    
        public void Initialize(float value, TimeMod mod)
        {
            currentMod = mod;
            cycleBar.fillAmount = GetProgressbarValue(value);
        }
    
        public void UpdateValue(float value)
        {
            CheckTimeMod(value);
            cycleBar.fillAmount = GetProgressbarValue(value);
        }
    
        private void CheckTimeMod(float value)
        {
            if (Mathf.Abs(value - 1) < 0.01f)
            {
                currentMod = TimeMod.PM;
            }
    
            if (Mathf.Abs(value) < 0.01f)
            {
                currentMod = TimeMod.AM;
            }
        }
    
        private float GetProgressbarValue(float value)
        {
            switch (currentMod)
            {
                case TimeMod.AM:
                    return value / 2;
                case TimeMod.PM:
                    return 0.5f + Mathf.Abs(value-1) / 2;
                default:
                    throw new ArgumentOutOfRangeException("currentMod", currentMod, null);
            }
        }
    
        public enum TimeMod
        {
            AM,
            PM
        }
    }

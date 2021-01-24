    using UnityEngine;
    
    public class Controller : MonoBehaviour
    {
        [SerializeField]
        private CycleBar cycleBar;
    
        private void Update() // TimeHandler
        {
            var value = Mathf.PingPong(Time.time, 1); // handle the time
            cycleBar.UpdateValue(value);
        }
    }

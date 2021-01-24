    public class Timer : MonoBehaviour
    {
        private static float _lastTime = Time.realtimeSinceStartup;
        [SerializeField, Tooltip("Time in second between timer ding dong."), Range(0f, 3600f)]
        private float _interval = 5f;
        public UnityEvent OnTickTack;
        private void Update()
        {
            if (Time.realtimeSinceStartup - _lastTime >= _interval)
            {
                _lastTime = Time.realtimeSinceStartup;
                OnTickTack.Invoke();
            }
        }
    }

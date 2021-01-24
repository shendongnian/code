    public class SunScript : MonoBehaviour
    {
        public float duration = 1.0F;
        public AnimationCurve curve;
        private Light lt;
        void Start()
        {
            lt = GetComponent<Light>();
        }
        void Update()
        {
            lt.intensity = curve.Evaluate((Time.time % duration) / duration);
        }
    }

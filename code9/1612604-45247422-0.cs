    public class SpinObject : MonoBehaviour {
        float timeSinceLastRotation;
        float timeUntilNextRotation = 0.01f; // 0.01 seconds
        void Update () {
            if (timeSinceLastRotation + timeUntilNextRotation > Time.time) {
                transform.Rotate(Vector3.forward, 10);
                timeSinceLastRotation = Time.time
            }
        }
    }

    public class SpinObject : MonoBehaviour {
        float rotationMultiplier = 1.0f;
        void Update () {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotationMultiplier);
        }
    }

    public class BoxScript : MonoBehaviour {
        public float fallspeed = 8.0f;
        public bool fall = false;
        void Update () {
            if (fall) {
                transform.Translate (Vector3.down * fallspeed * Time.deltaTime, Space.World);
            }
        }
    }

    public class respawn : MonoBehaviour
    {
        public Timer timer;
        public float threshold;
        void FixedUpdate()
        {
            if (transform.position.y < threshold)
            {
            //transform.position = new Vector3(403, 266, 337);
            timer.StartTimer();
            }
        }
    }

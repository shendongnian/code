    public class Collectable : MonoBehaviour
    {
        private bool collected;
        public bool Collected { get { return collected; } }
        void OnTriggerEnter(Collider other)
        {
            PlayerFollower ai = other.GetComponent<PlayerFollower>(); 
    
            if (ai != null)
            {
                collected = true;
                ai.Collect(this);
            }
        }
    }

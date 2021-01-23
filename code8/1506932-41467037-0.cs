    public class Stats : MonoBehaviour
    {
    
        public List<Effect> effects;
        private MonoBehaviour mono;
    
        public MonoBehaviour monoRef
        {
            get
            {
                return mono;
            }
        }
    
    
        // Use this for initialization
        void Awake()
        {
            mono = this;
        }
    }

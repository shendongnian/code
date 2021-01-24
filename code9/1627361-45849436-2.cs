    public class Room : MonoBehaviour
    {
    
        public ClassB classBTestInstance;
    
        // Use this for initialization
        void Start()
        {
            classBTestInstance = new ClassB(3);
        }
    }

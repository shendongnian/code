    public class Room : MonoBehaviour
    {
    
        public ClassB classBTestInstance = new ClassB(3);
    
        // Use this for initialization
        void Start()
        {
            Thread thread = Thread.CurrentThread;
            Debug.Log("Room (MainThread) Thread ID: " + thread.ManagedThreadId);
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    }
 

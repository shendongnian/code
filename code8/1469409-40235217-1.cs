    public class YourClassName: MonoBehaviour
    {
        public static YourClassName instance;
    
        public void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
        }
    
        public void YourMethodToCall()
        {
            //Do what you want here
        }
    }

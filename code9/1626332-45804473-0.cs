    public class Player : MonoBehaviour
    {
        private static Player _instance;
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Player>();
                }
               return _instance;
            }
        }
        // Reset of your class
    }

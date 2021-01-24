    public class MusicPlayer : MonoBehaviour
    {
        public static GameObject instance = null;
    
        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                Debug.Log("Duplicate MusicPlayer Destroyed");
            }
    
            else
            {
                instance = this.gameObject;
                GameObject.DontDestroyOnLoad(gameObject);
                Debug.Log("Original MusicPlayer Created!");
            }
        }
    }

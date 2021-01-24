    public class Menu : MonoBehaviour
    {
        private void Start()
        {
            Destroy(FindObjectOfType<Manager>());
        }
    }
    public class Manager : MonoBehaviour
    {
          private static Manager instance = null;
    
          private void Awake()
          {
              if (instance == null)
              { 
                   instance = this;
                   DontDestroyOnLoad(gameObject);
                   return;
              }
              if (instance == this) return; 
              Destroy(gameObject);
          }
    }

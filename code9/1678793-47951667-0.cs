    public class Menu:MonoBehaviour
    {
        void Start()
        {
            Destroy(FindObjectOfType<Manager>());
        }
    }
    public class Manager : MonoBehaviour
    {
          static Manager instance = null;
          void Awake()
          {
              if(instance == null)
              { 
                   instance = this;
                   DontDestroyOnLoad(this.gameObject);
                   return;
              }
              if(instance == this){ return; }
              Destroy(this.gameObject);
          }
    }

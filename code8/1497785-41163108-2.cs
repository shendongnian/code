    public class LoginController : MonoBehaviour
    {
    
        void Start()
        {
            Hide();
        }
    
        public void OnApplicationStarted(object source, EventArgs e)
        {
            Show();
        }
    
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
    
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    
        void OnEnable()
        {
            //Subscribe to event
            EventManager.Instance.registerEvent(OnApplicationStarted);
        }
    
        void OnDisable()
        {
            //Un-Subscribe to event
            EventManager.Instance.unRegisterEvent(OnApplicationStarted);
        }
    }

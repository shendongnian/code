    public class EventManager : MonoBehaviour
    {
        private static EventManager localInstance;
        public static EventManager Instance { get { return localInstance; } }
    
        private void Awake()
        {
            if (localInstance != null && localInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                localInstance = this;
            }
        }
    
        public delegate void ApplicationStartedEvent(object source, EventArgs args);
        private event ApplicationStartedEvent applicationStartedEvent;
    
    
        public void dispatchEvent(object source, EventArgs args)
        {
            foreach (ApplicationStartedEvent runEvent in applicationStartedEvent.GetInvocationList())
            {
                try
                {
                    runEvent.Invoke(source, args);
                }
                catch (Exception e)
                {
                    Debug.LogError(string.Format("Exception while invoking" + runEvent.Method.Name + e.Message));
                }
            }
        }
    
        public void registerEvent(ApplicationStartedEvent callBackFunc)
        {
            applicationStartedEvent += callBackFunc;
        }
    
        public void unRegisterEvent(ApplicationStartedEvent callBackFunc)
        {
            applicationStartedEvent -= callBackFunc;
        }
    }

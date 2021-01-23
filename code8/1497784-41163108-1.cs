    public class Application2 : IApplication
    {
        public void run()
        {
            OnApplicationStarted();
        }
    
        protected virtual void OnApplicationStarted()
        {
            EventManager.Instance.dispatchEvent(this, EventArgs.Empty);
        }
    }

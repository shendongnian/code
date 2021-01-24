    public class TopshelfService
    {
        private IDisposable moDisposable = null;
    
        public void Start()
        {
            this.moDisposable = WebApp.Start<Startup>("http://localhost:9989");
        }
    
        public void Stop()
        {
            this.moDisposable?.Dispose();
        }
    }

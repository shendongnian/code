    public class ChromeDriverService : IDriverService 
    {
        private static ChromeDriverService instance;
        
        private readonly Thread _thread;
        private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();
        private volatile bool _running;
        
        private ChromeDriverService() 
        {
            _thread = new Thread();
            _thread.Start();            
        }
        
        public static IDriverService Instance()
        {
            if (instance == null)
                instance = new ChromeDriverService();
            return instance;
        }
        
        // This will run on the "target" _thread
        public void StartDriverService()
        {
            while (true)
            {
                Action action;
                if (_actions.TryDequeue(out action))
                {
                    try
                    {
                        action();
                    }
                    catch (Exception ex) { // Handle }
                }
                else
                {
                    if (!_running && _actions.IsEmpty)
                        return;
                }
            }
        }
        
        public void StopDriverService()
        {
            _running = false;
            
            // IMPORTANT: Finish the logic here - we have a chance for race conditions. Dequeuing before the 
            // last action runs for example. This is primative, but you will have to take care of this. 
            while (!_actions.IsEmpty)
            {
                // Do stuff.
            }
        }
        
        // Called from some other thread.
        public void PerformDriverAction(Action action)
        {
            if (_running)
                _actions.Enqueue(action);
        }
    }
    

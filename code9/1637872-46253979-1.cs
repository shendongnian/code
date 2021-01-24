    public class PresenceMonitor
    {
        private volatile bool _running; // possible not needed "volatile" anymore
        private readonly int _presenceCheckInterval = 60000; // Milliseconds
        
        public PresenceMonitor()
        {
        }
    
        public async Task Start()
        {
            while (true) // may be use some "exit" logic
            {
               await CheckAsync();
               await Task.Delay(_presenceCheckInterval) 
            }
        }
    
        private async Task CheckAsync()
        {
            if (_running)
            {
                return;
            }
    
            _running = true;
    
            // await DoworkAsync
        }
    } 

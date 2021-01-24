    public class PresenceMonitor {
        private volatile bool _running;
        private Timer _timer;
        private readonly TimeSpan _presenceCheckInterval = TimeSpan.FromMinutes(1);
        public PresenceMonitor() {
        }
        public void Start() {
            // Start the timer
            timer = new System.Threading.Timer(_ => {
                Tick(this, EventArgs.Empty);//raise event
            }, null, TimeSpan.Zero, _presenceCheckInterval);
        }
        private event EventHandler Tick = delegate { };
        private async void OnTick(object sender, EventArgs args) {
            if (_running) {
                return;
            }
            _running = true;
            await DoworkAsync();
        }
        private Task DoworkAsync() {
            throw new NotImplementedException();
        }
    }

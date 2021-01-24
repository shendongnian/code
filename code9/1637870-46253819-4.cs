    public class PresenceMonitor {
        private volatile bool _running;
        private Timer timer;
        private readonly TimeSpan _presenceCheckInterval = TimeSpan.FromMinutes(1);
        public PresenceMonitor() {
            Tick += OnTick;
        }
        public void Start() {
            if (_running) {
                return; //already running
            }
            // Start the timer
            timer = new System.Threading.Timer(_ => {
                Tick(this, EventArgs.Empty);//rasie event
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
            //...
        }
    }

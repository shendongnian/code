    public class SingleInstanceRegisterService: IDisposable
    {
        private ConcurrentDictionary<SingleInstance,SingleInstance> dict = new ConcurrentDictionary<SingleInstance, SingleInstance>();
        AutoResetEvent arv;
        Timer timer;
        public SingleInstanceRegisterService()
        {
            arv = new AutoResetEvent(false);
            timer = new Timer(this.Cleanup, arv, 0, 60000);
        }
        public bool TryAdd(SingleInstance i)
        {
            return dict.TryAdd(i, i);
        }
        public bool ContainsKey(SingleInstance i)
        {
            return dict.ContainsKey(i);            
        }
        public bool TryRemove(SingleInstance i)
        {
            SingleInstance x;
            return dict.TryRemove(i, out x);
        }
        public void Cleanup(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            if (dict != null)
            {
                foreach(SingleInstance i in dict.Keys)
                {
                    if (i.Expiry < DateTimeOffset.Now)
                    {
                        TryRemove(i);
                    }
                }
            }
            autoEvent.Set();
        }
        public void Dispose()
        {
            timer?.Dispose();
            timer = null;
        }
    }

    public class GUIDManager
    {
    
        private static GUIDManager _instance;
        private Guid _activeGuid;
    
        public Guid ActiveGuid {
            get { return _activeGuid; }
            set { _activeGuid = value; }
    
        }
    
        private GUIDManager()
        {
            if (_activeGuid == null)
                _activeGuid = new Guid();
        }
    
        public static GUIDManager GetInstance()
        {
    
            if(_instance == null)
            {
                _instance = new GUIDManager();
            }
    
            return _instance;
        }
    
    }
    
    public class WorkerB
    {
    
        public string UniqueId = string.Empty;
    
        public WorkerB()
        {
            var manager = GUIDManager.GetInstance();
            UniqueId = manager.ActiveGuid.ToString();
        }
    
        public void DoWork()
        {
            var worker = new WorkerC();
            worker.DoWork();
        }
    }

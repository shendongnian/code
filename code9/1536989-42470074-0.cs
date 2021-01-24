    public class AppSession() {
        private static readonly Lazy<AppSession> _instance = 
            new Lazy<AppSession>(
                () => new LazyAppsession(), isThreadSafe: true
            );
        public static AppSession Instance { 
            get { return _instance.Value; } 
        }
    
        private AppSession() { }
    
        private string _actionName = "none";
        private DateTime? _actionTime = null;        
        public void ActionExecuted(string action) {
            _actionName = action ?? String.Empty;
            _actionTime = DateTime.UtcNow;
        }
    }

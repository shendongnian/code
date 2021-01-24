    public sealed class ApplicationState
    {
        private static readonly ApplicationState instance = new ApplicationState();
    
        static ApplicationState()
        {
        }
    
        private ApplicationState()
        {
        }
    
        public static ApplicationState Instance
        {
            get
            {
                return instance;
            }
        }
    
    
        public string SharedString {get;set;}
    }

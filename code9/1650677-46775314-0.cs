    public sealed class ProgressEvent
    {
        public EventHandler AddModule;
        private static ProgressEvent _instance = new ProgressEvent();
        public static ProgressEvent GetInstance()
        {
            return _instance;
        }
        public void OnAddModule(object sender, EventArgs e)
        {
            var addModuleDelegate = AddModule as EventHandler;
            if(addModuleDelegate != null)
            {
                addModuleDelegate.Invoke(sender, e);
            }
        }
    }

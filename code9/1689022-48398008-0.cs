    public class OutlineManager
    {
        private DTE dte;
        
        public OutlineManager()
        {
            dte = Package.GetGlobalService(typeof(DTE)) as DTE;
            dte.Events.WindowEvents.WindowActivated += OnWindowActivated;
        }
        private void OnWindowActivated(Window gotFocus, Window lostFocus)
        {
            //This is run when a new "window"(panel) gains focus (not only the code window though)
        }
    }

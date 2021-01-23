    public delegate void EventHandler();
    class someClass
    {
        WrapperForm dlg = null;
        System.Threading.Timer stateTimer;
        public static event EventHandler _show;
        public void CallToChildThread(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            //Check IPC
            //Fire event
            _show.Invoke();
        }
        public someClass()
        {
            initializeDialog(); // Initialize the dialog. Standard new
            var autoEvent = new AutoResetEvent(false);
            stateTimer = new System.Threading.Timer(CallToChildThread,
                                       autoEvent, 1000, 250);
            _show += new EventHandler(eventCheck);
        }
        void eventCheck()
        {
            //If some condition
            dlg.ShowDialog();
        }
    }

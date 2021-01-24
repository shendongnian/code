    internal class MessageLoop
    {
        private bool _running;
        private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();
        [DllImport("user32.dll")]
        static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport("user32.dll")]
        static extern bool TranslateMessage([In] ref MSG lpMsg);
        [DllImport("user32.dll")]
        static extern IntPtr DispatchMessage([In] ref MSG lpmsg);
        public MessageLoop()
        {
            Start();
        }
        public void Start()
        {
            _running = true;
            Thread t = new Thread(RunMessageLoop) {Name = "UI Thread", IsBackground = true};
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void RunMessageLoop()
        {
            while (_running)
            {
                while (_actions.Count > 0)
                {
                    Action action;
                    if (_actions.TryDequeue(out action))
                        action();
                }
                MSG msg;
                var res = GetMessage(out msg, IntPtr.Zero, 0, 0);
                if (res <= 0)
                {
                    _running = false;
                    break;
                }
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }
        public void Stop()
        {
            _running = false;
        }
        public void AddMessage(Action act)
        {
            _actions.Enqueue(act);
        }
    }

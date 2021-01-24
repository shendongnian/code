    public partial class Form1 : Form
    {
        private IntPtr NotepadhWnd;
        private IntPtr hWinEventHook;
        private Process Target;
        private WinApi.RECT rect = new WinApi.RECT();
        protected Hook.WinEventDelegate WinEventDelegate;
        public Form1()
        {
            InitializeComponent();
            WinEventDelegate = new Hook.WinEventDelegate(WinEventCallback);
            try
            {
                Target = Process.GetProcessesByName("notepad").FirstOrDefault(p => p != null);
                if (Target != null)
                {
                    NotepadhWnd = Target.MainWindowHandle;
                    uint TargetThreadId = Hook.GetWindowThread(NotepadhWnd);
                    if (NotepadhWnd != IntPtr.Zero)
                    {
                        hWinEventHook = Hook.WinEventHookOne(Hook.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, 
                                                             WinEventDelegate, 
                                                             (uint)Target.Id, 
                                                             TargetThreadId);
                        rect = Hook.GetWindowRect(NotepadhWnd);
                        this.Location = new Point(rect.Right, rect.Top);
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorManager.Logger(this, this.InitializeComponent(), ex.HResult, ex.Data, DateTime.Now);
                throw ex;
            }
        }
        protected void WinEventCallback(IntPtr hWinEventHook, 
                                        Hook.SWEH_Events eventType, 
                                        IntPtr hWnd, 
                                        Hook.SWEH_ObjectId idObject, 
                                        long idChild, 
                                        uint dwEventThread, 
                                        uint dwmsEventTime)
        {
            if (hWnd == NotepadhWnd && 
                eventType == Hook.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE && 
                idObject == (Hook.SWEH_ObjectId)Hook.SWEH_CHILDID_SELF)
            {
                WinApi.RECT rect = Hook.GetWindowRect(hWnd);
                this.Location = new Point(rect.Right, rect.Top);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hook.WinEventUnhook(hWinEventHook);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Target == null)
            {
                this.Hide();
                MessageBox.Show("Notepad not found!", "Target Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Close();
            }
            else
            {
                this.Size = new Size(50, 140);
            }
        }

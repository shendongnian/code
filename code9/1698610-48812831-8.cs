    public partial class Form1 : Form
    {
        private IntPtr notepadhWnd;
        private IntPtr hWinEventHook;
        private Process targetProc;
        private RECT rect = new RECT();
        protected Hook.WinEventDelegate WinEventDelegate;
        static GCHandle GCSafetyHandle;
        public Form1()
        {
            InitializeComponent();
            WinEventDelegate = new Hook.WinEventDelegate(WinEventCallback);
            GCSafetyHandle = GCHandle.Alloc(WinEventDelegate);
            try
            {
                targetProc = Process.GetProcessesByName("notepad").FirstOrDefault(p => p != null);
                if (targetProc != null)
                {
                    notepadhWnd = targetProc.MainWindowHandle;
                    uint targetThreadId = Hook.GetWindowThread(notepadhWnd);
                    if (notepadhWnd != IntPtr.Zero)
                    {
                        hWinEventHook = Hook.WinEventHookOne(Hook.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, 
                                                             WinEventDelegate, 
                                                             (uint)targetProc.Id, 
                                                             targetThreadId);
                        rect = Hook.GetWindowRect(notepadhWnd);
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
            if (hWnd == notepadhWnd && 
                eventType == Hook.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE && 
                idObject == (Hook.SWEH_ObjectId)Hook.SWEH_CHILDID_SELF)
            {
                rect = Hook.GetWindowRect(hWnd);
                this.Location = new Point(rect.Right, rect.Top);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GCSafetyHandle.Free();
            Hook.WinEventUnhook(hWinEventHook);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (targetProc == null)
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

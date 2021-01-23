    public partial class Form2 : Form
    {
        private ReturnType _getType; // thread safe
        private BackgroundWorker _bwThread;
        public enum ReturnType { MenuStrip, String, Integer }
        public Form2() // Do Not Call this method
        {
            InitializeComponent();
        }
        public void StartThread(Form1 parent, Object argument, ReturnType getType)
        {
            _getType = getType;
            if (_bwThread == null)
            {
                _bwThread = new BackgroundWorker() {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                _bwThread.DoWork += ThreadWork;
                _bwThread.ProgressChanged += parent.Form2_ThreadChanged;
                _bwThread.RunWorkerCompleted += parent.Form2_ThreadCompleted;
            }
            if (!_bwThread.IsBusy)
            {
                _bwThread.RunWorkerAsync(argument);
            }
        }
        private void ThreadWork(object sender, DoWorkEventArgs e)
        {
            switch (_getType)
            {
                case ReturnType.MenuStrip:
                    var menuStrip = new MenuStrip();
                    if (e.Argument != null)
                    {
                        var mi = (ToolStripMenuItem)e.Argument;
                        menuStrip.Items.Add(mi);
                    }
                    _bwThread.ReportProgress((int)_getType, menuStrip);
                    break;
                case ReturnType.Integer:
                    var numberBack = 1;
                    _bwThread.ReportProgress((int)_getType, numberBack);
                    break;
                case ReturnType.String:
                    var stringBack = "Worker String";
                    _bwThread.ReportProgress((int)_getType, stringBack);
                    break;
            }
        }
    }

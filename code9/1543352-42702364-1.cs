    public partial class Form1 : Form
    {
        private readonly CancellableBackgroundWorker _backgroundWorker;
        public Form1()
        {
            InitializeComponent();
            _backgroundWorker = new CancellableBackgroundWorker(DoBackgroundJob);
            _backgroundWorker.FinishedEvent += (s, e) => UpdateButton();
            // ensure this.components is created either by InitializeComponent or by us explicitly
            // so we can add _backgroundWorker to it for disposal
            if (this.components == null)
                this.components = new System.ComponentModel.Container();
            components.Add(_backgroundWorker);
        }
        private void UpdateButton()
        {
            // Ensure we interact with UI on the main thread
            if (InvokeRequired)
            {
                Invoke((Action)UpdateButton);
                return;
            }
            button1.Text = _backgroundWorker.IsBusy ? "Cancel" : "Start";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_backgroundWorker.IsBusy)
            {
                _backgroundWorker.Cancel();
            }
            else
            {
                _backgroundWorker.Start();
            }
            UpdateButton();
        }
        private void DoBackgroundJob(ICancellationProvider cancellation)
        {
            Debug.WriteLine("Do something");
            // if canceled, stop immediately
            cancellation.CheckForCancelAndBreak();
            Debug.WriteLine("Do something more");
            if (cancellation.CheckForCancel())
            {
                // you noticed cancellation but still need to finish something
                Debug.WriteLine("Do some necessary clean up");
                return;
            }
            // Sleep but cancel will stop and break
            cancellation.SleepWithCancel(10000);
            Debug.WriteLine("Last bit of work");
        }
    }

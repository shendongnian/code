    public partial class Form1 : Form
    {
        System.Threading.Timer _timer;
        IProgress<string> _progress;
        public Form1()
        {
            InitializeComponent();
            _progress = new Progress<string>(msg => textBox1.Text += msg + "\r\n");
            _timer = new System.Threading.Timer(theCallback);
        }
        private async void theCallback(object state)
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(100);
                _progress.Report($"Boo {i}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
                _timer.Change(0, 10000);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Dispose();
            _timer = null;
            _progress = null;
        }
    }

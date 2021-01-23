    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(60000);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timeLabel.Text = TimeWriterSingleton.Instance.OutputTime();
            timer.Elapsed += TimerElapsed;
            timer.Enabled = true;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            timeLabel.Text = TimeWriterSingleton.Instance.OutputTime();
        }
    }

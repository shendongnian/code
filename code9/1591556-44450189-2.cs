    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (B01CountDown.InvokeRequired)
            {
                B01CountDown.Invoke((MethodInvoker)(() =>
                {
                    B01CountDown.Text = TimeCounter.TimerCount.ToString();
                }));
            }
        }
    }

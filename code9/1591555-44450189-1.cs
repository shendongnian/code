    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeCounter.TimerCount++;
        }        
    }

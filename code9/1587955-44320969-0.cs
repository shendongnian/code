    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000; // delay: 1000 milliseconds
        }
        Timer timer = new Timer();
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                timer.Stop();
                return;
            }
            progressBar1.Value += 25;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 25;
            timer.Start();
        }
    }

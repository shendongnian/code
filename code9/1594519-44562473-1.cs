    public partial class Form1 : Form
    {
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 25;
            timer.Tick += Timer_Tick;
            timer.Start();
            System.Windows.Forms.Timer timerTextbox = new System.Windows.Forms.Timer();
            timerTextbox.Interval = 1000;
            timerTextbox.Tick += TimerTextbox_Tick; ;
            timerTextbox.Start();
            
        }
        private void TimerTextbox_Tick(object sender, EventArgs e)
        {
            FillB();
            (sender as System.Windows.Forms.Timer).Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(counter.ToString());
            counter++;
            listBox1.Update();
        }
        private void FillB()
        {
          textBox1.Text = "Hello World!";
        }
    }

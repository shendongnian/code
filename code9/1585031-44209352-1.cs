    public partial class Form1 : Form
    {
        readonly System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private int tickCounter;
        public Form1()
        {
            InitializeComponent();
            myTimer.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            myTimer.Tick += StartMethod;
        }
        private void StartMethod(object sender, EventArgs e)
        {
            tickCounter++;
            label1.Text = "Number of executions: " + tickCounter;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tickCounter = 0;
            label1.Text = "Started!";
            myTimer.Enabled = true;
        }
    }

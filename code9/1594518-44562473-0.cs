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
            FillB();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(counter.ToString());
            counter++;
            listBox1.Update();
        }
        private void FillB()
        {
            Thread.Sleep(3000); //1 seconds delay
            textBox1.Text = "Hello World!";
        }
    }

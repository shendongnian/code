    public partial class Form1 : Form
    {
        private Timer timer1;
    
        public static int fNumber = 0, sNumber = 0,flag = 0;
        public Form1()
        {
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            InitializeComponent();
        }
    
        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    
        private void number1_TextChanged(object sender, EventArgs e)
        {
    
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            int.TryParse(this.number1.Text, out i);
            i++;
            if(this.number1.InvokeRequired)
            {
                this.number1.BeginInvoke((MethodInvoker) delegate() 
                {
                    this.number1.Text = Convert.ToString(i);
                });    
            }
            else
            {
                this.number1.Text = Convert.ToString(i);
            }
        }
    }

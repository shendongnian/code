    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //calculate your time and perform whatever action here
        }
    }

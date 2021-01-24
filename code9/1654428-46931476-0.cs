    public partial class Form1 : Form
    {
        Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        private void _timer_Tick(Object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
    }

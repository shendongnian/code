    public partial class Form1 : Form
    {
        Timer timer;
        double x;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 50;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
                timer.Stop();
            else timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(x, 3 * Math.Sin(5 * x) + 5 * Math.Cos(3 * x));
            if (chart1.Series[0].Points.Count > 100)
                chart1.Series[0].Points.RemoveAt(0);
            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = x;
            x += 0.1;
        }
    }

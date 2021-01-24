    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            double percent = 0.0025;
            List<DataPoint> original = GetData();
            List<DataPoint> filtered = Filter(original, percent);
            foreach (DataPoint dp in original)
                chart1.Series[0].Points.Add(dp);
            foreach (DataPoint dp in filtered)
                chart1.Series[1].Points.Add(dp);
            chart1.ChartAreas[0].AxisY.Maximum = original.Max(dp => dp.YValues[0]);
            chart1.ChartAreas[0].AxisY.Minimum = original.Min(dp => dp.YValues[0]);
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            Text = string.Format("original = {0:0,0} points, filtered = {1:0,0} points, percent = {2:P2}", original.Count, filtered.Count, percent);
        }
        private List<DataPoint> Filter(List<DataPoint> orig, double percent)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            List<DataPoint> filt = new List<DataPoint>(orig.ToArray());
            double total = filt.Count;
            while (filt.Count / total > percent)
                filt.RemoveAt(r.Next(1, filt.Count - 1));
            return filt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Series[0].Enabled)
            {
                chart1.Series[0].Enabled = false;
                chart1.Series[1].Enabled = true;
            }
            else
            {
                chart1.Series[0].Enabled = true;
                chart1.Series[1].Enabled = false;
            }
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Add("test");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Points.AddXY(1, 1);
            chart1.Series[0].Points.AddXY(2, 2);
            chart1.Series[0].Points.AddXY(3, 3);
            chart2.Series.Add("test2");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Series series in chart1.Series)
                foreach (DataPoint point in series.Points)
                    if (point.XValue >= 2)
                        chart2.Series[chart1.Series.IndexOf(series)].Points.Add(point);
        }
    }

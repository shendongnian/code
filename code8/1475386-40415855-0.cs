    DataTable table = new DataTable();
    Random random = new Random();
    private void Form1_Load(object sender, EventArgs e)
    {
        table.Columns.Add("X", typeof(int));
        table.Columns.Add("Y", typeof(double));
        for (int i = 0; i < 10; i++)
            table.Rows.Add(i+1, random.Next(100));
        chart1.Series[0].ChartType = 
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        chart1.Series[0].XValueMember = "X";
        chart1.Series[0].YValueMembers = "Y";
        chart1.DataSource = table;
        chart1.ChartAreas[0].AxisX.Interval = 1;
        chart1.ChartAreas[0].AxisX.Minimum = 0;
        chart1.ChartAreas[0].AxisX.Maximum = 10;
        chart1.ChartAreas[0].AxisY.Interval = 10;
        chart1.ChartAreas[0].AxisY.Minimum = 0;
        chart1.ChartAreas[0].AxisY.Maximum = 100;
        chart1.DataBind();
        var timer = new Timer() { Interval= 300};
        timer.Tick += timer_Tick;
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
            table.Rows[i][1]= random.Next(100);
        chart1.DataBind();
    }

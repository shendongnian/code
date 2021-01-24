    List<SeriesChartType> typeList = new List<SeriesChartType>() {
                                         SeriesChartType.Pie, 
                                         SeriesChartType.Line, 
                                         SeriesChartType.Bar };
    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DataSource = typeList;
    }

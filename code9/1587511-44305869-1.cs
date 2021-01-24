    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex >= 0)
        {
            SeriesChartType type = typeList[comboBox1.SelectedIndex];
            List<int> values = new List<int> { 1, 2, 3, 3, 3, 3, 4, 5, 6, 6, 6, 4, 4, 3, 2, 2, 1, 1 };
            chart1.Series[0].Points.DataBindY(values);
            chart1.Series[0].ChartType = type;
        }
    }

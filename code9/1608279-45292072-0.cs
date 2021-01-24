     protected void Chart4_Load(object sender, EventArgs e)
     {
        Chart4.Series[0].Points.Add(new DataPoint(0, (double)ChartData.Rows[0]["unchecked_percent"]));
        Chart4.Series[0].Points.Add(new DataPoint(1, (double)ChartData.Rows[0]["checked_percent"]));
     }

    private DataTable Load()
    {
        var dt = new DataTable();
        dt.Columns.Add("chart");
        for(int r=0; r<10; r++)
        {
            var rw = dt.NewRow();
            rw[0] = Guid.NewGuid().ToString("N");
            dt.Rows.Add(rw);
        }
        return dt;
    }
    Random rnd = new Random();
    private void GenerateChart(DataRow row)
    {
        chart1.Series.Clear();
        chart1.Series.Add("data");
        var mx = rnd.Next(rnd.Next(10) + 3);
        for (int x = 0; x < mx; x++)
        {
            chart1.Series[0].Points.Add(x, rnd.Next(100));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Chart1.Palette = ChartColorPalette.None;
        Chart1.PaletteCustomColors = new Color[] { ColorTranslator.FromHtml("#DF5B59"), ColorTranslator.FromHtml("#E0D773 "), ColorTranslator.FromHtml("#8AAC53"), ColorTranslator.FromHtml("#6A843F") };
        Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        Chart1.ChartAreas[0].AxisX.Interval = 1;
        var rows = from row in dt.AsEnumerable() select row.Field<int>("OutcomeScore");
        Chart1.Series.Clear();
        foreach (int i in rows.Distinct())
            Chart1.Series.Add(new Series { Name = i.ToString(), ChartType = SeriesChartType.StackedColumn });
        foreach (DataRow dr in dt.Rows)
        {
            DataPoint dp = new DataPoint();
            dp.AxisLabel = dr["TermID"].ToString();
            dp.Label = dr["RecordsPerGroup"].ToString();
            dp.XValue = (int)dr["TermID"];
            dp.YValues[0] = (int)dr["RecordsPerGroup"];
            string name = dr["OutcomeScore"].ToString();
            Chart1.Series[name].Points.Add(dp);
        }
    }

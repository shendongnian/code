        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DataRow r in dt.Rows)
            {
                Series s = new Series((string)r["Month"]);
                s.ChartType = SeriesChartType.Column;
                s.Points.AddXY("Charges", new object[] { r["Charges"] });
                s.Points.AddXY("Payments", new object[] { r["Payments"] });
                Chart1.Series.Add(s);
            }
        }

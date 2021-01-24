        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in graphdata.Rows)
            {
                int total = (int)row["total time"];
                int index = chart1.Series[0].Points.AddXY(row["User"], new object[] { total });
                chart1.Series[0].Points[index].Label = string.Format("{0:00}:{1:00}:{2:00}", (total / 60) / 60, (total / 60) % 60, total % 60);
            }
        }

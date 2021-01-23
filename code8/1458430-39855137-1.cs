        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime[] x = new DateTime[3];
            int[] y = new int[3];
            for (int i = 0; i < 3; i++)
            {
                x[i] = DateTime.Now.AddDays(i);
                y[i] = 10 * (i + 1);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd-yy";
        }

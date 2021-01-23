        protected void Page_Load(object sender, EventArgs e)
        {
            for (int x = 1; x <= 5; x++)
                Chart1.Series[0].Points.AddXY(x, 10 * x);
            Chart1.Series[0].Points[3].BackHatchStyle = ChartHatchStyle.Cross;
            Chart1.Series[0].Points[3].Color = Color.Orange;
        }

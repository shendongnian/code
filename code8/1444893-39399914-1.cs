        private void graph2()
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            setChart();
        }
        
        private void setChart()
        {
            switch (metroComboBox1.SelectedText.ToString())
            {
                case "Name 1":
                    finalizeChart();
                    break;
                case "Name 2":
                    finalizeChart();
                    break;
            }
        }
        private void finalizeChart()
        {
            for (int i = 0; i < metroGrid2.Rows.Count - 1; i++)
            {
                                    int x = 0;
                    Int32.TryParse(metroGrid2.Rows[i].Cells[4].Value.ToString(), out x);
                    DateTime dt;
                    DateTime.TryParse(metroGrid2.Rows[i].Cells[5].Value.ToString(), out dt);
                    chart1.Series[i].Points.AddXY(metroGrid2.Rows[i].Cells[5].Value.ToString(), metroGrid2.Rows[i].Cells[4].Value.ToString());
                    if (metroComboBox3.Text == "Text 1")
                    {
                        chart1.Series[i].Color = Color.Red;
                    }
                    if (metroComboBox3.Text == "Text 2")
                    {
                        chart1.Series[i].Color = Color.Green;
                    }
                    //chart1.Series[0].Points[5].Color = Color.Blue;
                    //Console.WriteLine(chart1.Series[0].Points.AddXY(metroGrid1.Rows[i].Cells[5].Value.ToString(), metroGrid1.Rows[i].Cells[4].Value.ToString()));
                
            }
        }

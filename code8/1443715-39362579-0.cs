    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            if (metroComboBox1.Text == "Text 1")
            {
              
               
                for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
                {
                    foreach (DataGridViewRow row in metroGrid1.Rows)
                    {
                        int x = 0;
                        Int32.TryParse(metroGrid1.Rows[i].Cells[4].Value.ToString(), out x);
                        DateTime dt;
                        DateTime.TryParse(metroGrid1.Rows[i].Cells[5].Value.ToString(), out dt);
                        chart1.Series[0].Points.AddXY(metroGrid1.Rows[i].Cells[5].Value.ToString(), metroGrid1.Rows[i].Cells[4].Value.ToString());
                        //Console.WriteLine(chart1.Series[0].Points.AddXY(metroGrid1.Rows[i].Cells[5].Value.ToString(), metroGrid1.Rows[i].Cells[4].Value.ToString()));
                    }
                }
            }
            if (metroComboBox1.Text == "Text 2")
            {........
            
            

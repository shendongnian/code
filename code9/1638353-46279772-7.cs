        int visibleCount = 5;
        float yOffTop = 0;     // no extra top space for a chart title
        float yOffBottom = 0;  // no extra  bottom space either
        float mainExtra = 6;   // a few extra% for the main CA's axis labels
        private void Init_button_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.BackColor = Color.Snow;
            float h = (100 - yOffTop - yOffBottom) / visibleCount;
            for (int i = 0; i < 13; i++)
            {
                float yOff = i != 0 ? mainExtra : 0;
                float yExtra = i == 0 ? mainExtra : 0;
                ChartArea ca = chart1.ChartAreas.Add("ca" + i);
                ca.Position = new ElementPosition(0, h * i + yOff , 80, h + yExtra);
                ca.BackColor = Color.FromArgb(i * 20, 255 - i * 3, 255);
                ca.AxisX.IntervalOffset = 1;
                Series s = chart1.Series.Add("s" + i);
                s.ChartArea = ca.Name;
                for (int j = 1; j < 30; j++)
                {
                    s.Points.AddXY(j, rnd.Next(100) - rnd.Next(20));
                }
                chart1.ChartAreas[0].BackColor = Color.Silver;
                ca.AxisY.Title = i == 0 ? "Year" :
                                           DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
                ca.AxisX.Enabled = (i == 0) ? AxisEnabled.True :  AxisEnabled.False;
            }
            vScrollBar1.Minimum = 0;// (int)( h);
            vScrollBar1.Maximum = (int)((chart1.ChartAreas.Count - visibleCount + 0.5f) * h
                                       + mainExtra );
        }

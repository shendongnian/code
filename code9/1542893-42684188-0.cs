        private void chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
            foreach (LegendItem li in e.LegendItems)
            {
                if (li.Cells[1].Text == "Series2")
                {
                    li.Cells[1].BackColor = Color.DarkGreen;
                    li.Cells[1].ForeColor = Color.White;
                }
            }
        }

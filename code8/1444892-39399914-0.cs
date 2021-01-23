    if (metroComboBox1.Text == "Name 2")
        {
            for (int i = 0; i < metroGrid2.Rows.Count - 1; i++)
            {
                                    int x = 0;
                    Int32.TryParse(metroGrid2.Rows[i].Cells[4].Value.ToString(), out x);
                    DateTime dt;
                    DateTime.TryParse(metroGrid2.Rows[i].Cells[5].Value.ToString(), out dt);
                    chart1.Series[i].Points.AddXY(metroGrid2.Rows[i].Cells[5].Value.ToString(), metroGrid2.Rows[i].Cells[4].Value.ToString());
                    if (metroComboBox3.Text == "Text1")
                    {
                        chart1.Series[i].Color = Color.Red;
                    }
                    if (metroComboBox3.Text == "text2")
                    {
                        chart1.Series[i].Color = Color.Green;
                    }
                    //Console.WriteLine(chart1.Series[00].Points.AddXY(metroGrid1.Rows[i].Cells[5].Value.ToString(), metroGrid1.Rows[i].Cells[4].Value.ToString()));
                }
            

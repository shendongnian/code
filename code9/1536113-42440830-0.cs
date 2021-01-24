     chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].Position.Auto = false;
            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Y = 0;
            chart1.ChartAreas[0].Position.Height = 90;
            chart1.ChartAreas[0].Position.Width = 90;
            chart1.ChartAreas[0].AlignmentStyle = AreaAlignmentStyles.All;
            chart1.ChartAreas[0].AlignmentOrientation = AreaAlignmentOrientations.All;
 		for (int i = 2002;i<2017;i++)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    OleDbCommand komut = new OleDbCommand("SELECT COUNT(No) AS Sayı FROM [main$] WHERE [Yil]="+i+"", con);
                    komut.Connection = con;
                    OleDbDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        chart1.Series.Add(dr["Sayı"].ToString());
                        chart1.Series[dr["Sayı"].ToString()].Points.AddXY(i, float.Parse(dr["Sayı"].ToString()));
                        chart1.Series[i2].Color = Color.Black;
                        chart1.Series[i2]["PixelPointWidth"] = "100";
                        chart1.Series[i2].IsVisibleInLegend = false;
                        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "####" + ((char)160) + "\n";
                        chart1.ChartAreas[0].AxisY.LabelStyle.Format = "####" + ((char)160) + "\n";           
                        i2 += 1;
                    }   
                }`
            

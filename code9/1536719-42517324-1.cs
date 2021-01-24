        private void chtWRMonthly_MouseClick(object sender, MouseEventArgs e)
    {
    string MonthName = "";
                Boolean S = true;
                Point MP = new Point(e.X);
                chtWRMonthly.ChartAreas[0].CursorX.Interval = 0;
                int X, Px = (int)chtWRMonthly.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                X = (int)Math.Round((float)chtWRMonthly.ChartAreas[0].AxisX.PixelPositionToValue(e.X)) - 1;
                MonthName = chtWRMonthly.Series[0].Points[X].AxisLabel;
                if (MonthName != "")
                {
                    if (Px >= X+1)
                        S = false;
    
                    SqlDataAdapter SDA = new SqlDataAdapter("ReportMonthlyShowInvoices", SCon);
                    SDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SDA.SelectCommand.Parameters.AddWithValue("@Year", Year);
                    SDA.SelectCommand.Parameters.AddWithValue("@Month", MonthsDic.First(Pair => Pair.Value == MonthName).Key);
                    SDA.SelectCommand.Parameters.AddWithValue("@S", S);
                    DataTable DT = new DataTable();
                    SDA.Fill(DT);
    }

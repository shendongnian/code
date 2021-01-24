    private void chart_SelectionRangeChanged(object sender, CursorEventArgs e)
    {
        ChartArea ca = chart.ChartAreas[0];
        var d0 = (int) ca.CursorX.SelectionStart;
        var d1 = (int) ca.CursorX.SelectionEnd;
        var spoints  = series2Export[0].Points.Where(x => x.XValue >= d0  && x.XValue <= d1).ToList();
        string del1 = ";";
        string del2 = "\t";
        string fmt1 = "yyyy.MM.dd";
        string fmt2 = "#0.0";
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.FileName = suggestedFilePath;
        sfd.Title =  (d1 - d0) + " points selected. Save data to..";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var dp0 in spoints)
            {
                int pi = chart.Series[0].Points.IndexOf(dp0);
                string st = "";
                foreach (var s in series2Export)
                {
                    DataPoint dp = s.Points[pi];
                    st +=  (DateTime.FromOADate(dp.XValue)).ToString(fmt1) + del1 + 
                            dp.YValues[0].ToString(fmt2) + del2;
                }
                sb.AppendLine(st);
            }
            File.WriteAllText(sfd.FileName, sb.ToString());
        }
    }

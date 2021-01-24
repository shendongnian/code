    using (TextReader tw = new StreamReader(@"yourfilename.xml"))
    {
        //chart.Series[0].Points.Clear();
        //sPoints.Clear();
        sPoints = (List<SPoint>)xs.Deserialize(tw);
        tw.Close();
    }
    foreach (var sp in sPoints) s.Points.Add(SPoint.FromSPoint(sp));

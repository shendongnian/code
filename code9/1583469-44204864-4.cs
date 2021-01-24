    List<DataPoint> PointsFromCsvLine(string line)
    {
        var parts = line.Split(',').ToList();        // use your separator
        DateTime dt = Convert.ToDateTime(parts[0]);  // add checks!
        double d1 = Convert.ToDouble(parts[1]);      // use..
        double d2 = Convert.ToDouble(parts[4]);      // ..your..
        double d3 = Convert.ToDouble(parts[9]);      // ..numbers!
        var points = new List<DataPoint>();
        points.Add(new DataPoint(  dt.ToOADate(), d1));
        points.Add(new DataPoint(  dt.ToOADate(), d2));
        points.Add(new DataPoint(  dt.ToOADate(), d3));
        points[0].Tag = line;
        return points;
    }
    string CsvLineFromPoint(Series series0, int index )
    {
        DataPoint dp = series0.Points[index];            // check index
        string s = dp.Tag.ToString();
        return s;
    }

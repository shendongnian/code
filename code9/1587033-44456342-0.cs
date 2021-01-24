    List<List<DataPoint>> GetSelectedPoints(ChartArea ca, Series S)
    {
        selectionPoints = new List<List<DataPoint>>();
        foreach (var sl in ca.AxisX.StripLines)
        {
            List<DataPoint> points = new List<DataPoint>();
            points = S.Points.Select(x => x)
                      .Where(x => x.XValue >= sl.IntervalOffset
                               && x.XValue <= (sl.IntervalOffset + sl.StripWidth)).ToList();
            selectionPoints.Add(points);
        }
        return selectionPoints;
    }

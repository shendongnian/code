    private void AddPoint(MouseButtonEventArgs e)
    {
        var curPoints = Areas[Areas.Count - 1];
        curPoints.Add(e.GetPosition((IInputElement)e.Source));
        //  ** fix ** 
        Areas[Areas.Count - 1] = new List<Point>(curPoints);
        //  ** end fix ** 
        if (e.ClickCount == 2 && curMaskPoints.Count > 0)
        {
            curMaskPoints.Add(curMaskPoints[0]);
            Areas.Add(new List<Point>());
        }
    }

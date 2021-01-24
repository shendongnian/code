    private int pieHitPointIndex(Chart pie, MouseEventArgs e)
    {
        HitTestResult hitPiece = pie.HitTest(e.X, e.Y, ChartElementType.DataPoint);
        HitTestResult hitLegend = pie.HitTest(e.X, e.Y, ChartElementType.LegendItem);
        int pointIndex = -1;
        if (hitPiece.Series != null) pointIndex = hitPiece.PointIndex;
        if (hitLegend.Series != null) pointIndex = hitLegend.PointIndex;
        return pointIndex;
    }
    private void pie_MouseClick(object sender, MouseEventArgs e)
    {
        Chart pie = (Chart)sender;
        int pointIndex = pieHitPointIndex(pie, e);
        if (pointIndex >= 0)
        {
            DataPoint dp = pie.Series[0].Points[pointIndex];
            // do what you want to do with a click
        }
    }
    private void pie_MouseMove(object sender, MouseEventArgs e)
    {
        Chart pie = (Chart)sender;
        int pointIndex = pieHitPointIndex(pie, e);
        if (pointIndex >= 0)
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Default;
        }
    }

    Point? xyPoint = GetCenterPoint(SearchButton);
                            
    if (xyPoint != null)
    {
       Mouse.Click((Point)xyPoint);
    }
    public Point? GetCenterPoint(UITestControl objTarget)
    {
        Point? _Point = null;
        try
        {
            if (objTarget != null && objTarget.GetProperty(UITestControl.PropertyNames.BoundingRectangle) != null)
            {
                double _CenterX = objTarget.BoundingRectangle.X + (objTarget.BoundingRectangle.Width / 2);
                int _PointX = Convert.ToInt32(_CenterX);
                double _CenterY = objTarget.BoundingRectangle.Y + (objTarget.BoundingRectangle.Height / 2);
                int _PointY = Convert.ToInt32(_CenterY);
                _Point = new Point(_PointX, _PointY);
            }
        }
        catch (Exception ex)
        {
            //Exception Logging Here
        }
        return _Point;
    }

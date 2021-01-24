    public struct Point
    {
      public double Angle { get; private set; }
    
      public Point(double referencePoint, double x, double y)
      {
        // TODO: Calculate Angle
      }
    }
    
    points.OrderBy(p => p.Angle);

    public static unsafe double CallGetArea(Point[] vertices, bool isClosed)
    {
      if (vertices.Length == 0) throw new ArgumentException("Vertices empty.", "vertices");
    
      fixed (Point* pVertices = &vertices[0])
      {
        return GetArea(pVertices, vertices.Length);
      }
    }
    
    public struct Point
    {
      public double x;
      public double y;
    }

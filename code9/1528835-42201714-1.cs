    struct Point
    {
      public double x;
      public double y;
    }
    [DllImport("myDll.dll", CallingConvention = CallingConvention.Cdecl)]
    public extern unsafe static double GetArea(Point[] vertices, int count, bool isClosed);

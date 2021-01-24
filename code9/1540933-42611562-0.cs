    [BenchmarkDotNet.Attributes.Benchmark(Baseline = true)]
    public static Point GetPoint()
    {
    	return new Point(x, y);
    }
    
    [BenchmarkDotNet.Attributes.Benchmark]
    public static Point GetPoint2()
    {
    	Point point = new Point();
    	point.x = x;
    	point.y = y;
    	return point;
    }

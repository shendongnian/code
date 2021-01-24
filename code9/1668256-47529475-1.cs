    private static void Main()
    {
        var points = new List<Point>
        {
            new Point(6, 60),
            new Point(7, 60),
            new Point(8, 60),
            new Point(9, 60),
            new Point(10, 60),
            new Point(10, 61),
            new Point(10, 62),
            new Point(10, 63),
            new Point(10, 64),
            new Point(10, 65),
            new Point(11, 65),
        };
        ProcessPoints(points);
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

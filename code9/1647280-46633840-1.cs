    class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        // Equals and get hash code here
    }
    class dwePoint
    {
        Point3D Coordinate {get;}
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
    }
    // Filter list by applying grouping and your custom logic
    points = points.GroupBy(p => p.Coordinate)
        .Select(x => 
            x.OrderByDescending(p => p.Prop1 == "Keep")  // Sort so the element you want to keep is first
             .First()                                    // If there is only one element, the ordering will not matter
        ).ToList();

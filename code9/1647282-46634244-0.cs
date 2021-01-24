    static void Main()
    {
        List<dwePoint> points = new List<dwePoint>();
        // Testdata
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                for (int z = 0; z < 3; z++)
                {
                    points.Add(new dwePoint { X = x, Y = y, Z = z });
                    if (x == y && x == z) // and some duplicates to Keep
                        points.Add(new dwePoint { X = x, Y = y, Z = z, Prop1 = "Keep" });
                }
        // prefer the ones with "Keep" in Prop1  
        var distincts = points.Aggregate(new HashSet<dwePoint>(), (acc, p) =>
        {
            if (acc.Contains(p))
            {
                var oldP = acc.First(point => point.X == p.X && point.Y == p.Y && point.Z == p.Z);
                if (oldP.Prop1 == "Keep")
                {
                    // do nothing - error, second point with "keep"
                }
                else
                {
                    acc.Remove(oldP);
                    acc.Add(p); // to use this ones other props later on ....
                }
            }
            else
                acc.Add(p);
            return acc;
        }).ToList();
        Console.WriteLine(string.Join(" - ", points));
        Console.WriteLine(string.Join(" - ", distincts));
        Console.ReadLine();
    }
 
    private class dwePoint
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as dwePoint);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }
        public override string ToString() => $"{X}-{Y}-{Z}-{Prop1}-{Prop2}-{Prop3}";
        protected bool Equals(dwePoint other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }
    }

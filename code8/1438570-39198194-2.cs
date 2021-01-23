	class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var random = new Random();
            List<Point> points = Enumerable.Range(0, 10000000).Select(x => new Point { X = random.Next(1000), Y = random.Next(1000) }).ToList();
            
            int conditionValue = 250;
            Console.WriteLine($"Condition value: {conditionValue}");
         
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int hitCount1 = 0;
            var points1 = points.Where(x =>
            {
                hitCount1++;
                return x.X < conditionValue;
            }).Select(x =>
            {
                hitCount1++;
                return x.Y;
            }).ToArray();
            
            sw.Stop();
            Console.WriteLine($"Where -> Select: {sw.ElapsedMilliseconds} ms, {hitCount1} hits");
            sw.Restart();
            int hitCount2 = 0;
            var points2 = points.Select(x =>
            {
                hitCount2++;
                return x.Y;
            }).Where(x =>
            {
                hitCount2++;
                return x < conditionValue;
            }).ToArray();
            sw.Stop();
            Console.WriteLine($"Select -> Where: {sw.ElapsedMilliseconds} ms, {hitCount2} hits");
            Console.ReadLine();
		}
	}

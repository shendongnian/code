    using System.Linq
    
    ...
    
    static class Util
    {
        static Random ran = new Random();
    
        public static List<Point3d> RandomptGenerator(int num)
        {
          return Enumerable
            .Range(0, num)
            .Select(_ => new Point3d(ran.Next(0, 40), ran.Next(0, 30), 0.0))
            .ToList();
       }
    } 

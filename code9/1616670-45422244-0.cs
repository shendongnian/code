     public class Coordinates {
       public decimal Z { get; set; }
       public List<Point> Polygons { get; set; }
     }
     public class Point{
      public List<vertex> points { get; set; } 
     }
     public class vertex{
       public List<decimal> Vertices { get; set; }
       public decimal x { get {return Vertices?[0]} }
       public decimal y { get {return Vertices?[1]} }
     }

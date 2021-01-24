         public class Program
            {
                public static void Main(string[] args)
                {
                    //Your code goes here
                    Console.WriteLine("Hello, world!");
                    List<DuluxColour> _colors= new List<DuluxColour>();
                    _colors.Add(new DuluxColour{Colour = Color.Black , ColourName ="Black"});
                        _colors.Add(new DuluxColour{Colour = Color.Red , ColourName ="Red"});
                        _colors.Add(new DuluxColour{Colour = Color.Green , ColourName ="Green"});
                        _colors.Add(new DuluxColour{Colour = Color.Yellow , ColourName ="Yellow"});
                    var col =ClosestColor(_colors, Color.Purple);
                    Console.Write(col.ColourName);
                }
                public static DuluxColour ClosestColor(List<DuluxColour> colours, Color target)
                {
                
                    var colorDiffs = colours.Select(n => ColorDiff(n.Colour, target)).Min(n => n);
                    return colours.Find(n => ColorDiff(n.Colour, target) == colorDiffs);
                }
        
                public static int ColorDiff(Color c1, Color c2)
                {
                    return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                           + (c1.G - c2.G) * (c1.G - c2.G)
                                           + (c1.B - c2.B) * (c1.B - c2.B));
                }
               
        
            }
       
    
      public class DuluxColour
            {
                public string ColourName { get; set; }
                public Color Colour { get; set; }
            }

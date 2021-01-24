    using System;
    
    namespace SysproWcfServiceSecureClient
    {
        class Program
        {
            public class Coordinate
            {
                public Coordinate((double Value, bool IsRelative) x, (double Value, bool IsRelative) y, (double Value, bool IsRelative) z)
                {
                    X = x;
                    Y = y;
                    Z = z;
                }
                public (double Value, bool IsRelative) X { get; }
                public (double Value, bool IsRelative) Y { get; }
                public (double Value, bool IsRelative) Z { get; }
    
                public override string ToString()
                {
                    return $"({X},{Y},{Z})";
                }
            }
    
            public static void SomeMethod(Coordinate coordinate)
            {
                Console.WriteLine(coordinate);
                Console.WriteLine(coordinate.X.Value);
                Console.WriteLine(coordinate.Y.IsRelative);
            }
    
            public static void Main()
            {
                var c = new Coordinate((100.0, true), (25.5, false), (100, true));
                SomeMethod(c);
                Console.ReadKey();
            }
        }
    }

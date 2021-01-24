    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace hash
    {
    
        public class MyPair
        {
            public int X { get; set; }
            public int Y { get; set; }
    
            public override int GetHashCode()
            {
                return X * 10000 + Y;
            }
    
            public override bool Equals(object obj)
            {
                MyPair other = obj as MyPair;
                return X == other.X && Y == other.Y;
            }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                HashSet<MyPair> hash = new HashSet<MyPair>();
                MyPair one = new MyPair { X = 10, Y = 2 };
                MyPair two = new MyPair { X = 1, Y = 24 };
                MyPair three = new MyPair { X = 111, Y = 266 };
                MyPair copyOfOne = new MyPair { X = 10, Y = 2 };
                Console.WriteLine(hash.Add(one));
                Console.WriteLine(hash.Add(two));
                Console.WriteLine(hash.Add(three));
                Console.WriteLine(hash.Add(copyOfOne));
            }  
            
        }
    }

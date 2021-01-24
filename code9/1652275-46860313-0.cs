    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace hashExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int[]> points = new List<int[]>();
                Random random = new Random();
                int toInsert = 20000;
                for (int i = 0; i < toInsert; i++)
                {
                    int x = random.Next(1000);
                    int y = random.Next(1000);
                    points.Add(new int[]{ x,y });
                }
                HashSet<int[]> set = new HashSet<int[]>(new SameHash());
                Stopwatch clock = new Stopwatch();
                clock.Start();
                foreach (var item in points)
                {
                    set.Add(item);
                }
                clock.Stop();
                Console.WriteLine("Elements inserted: " + set.Count + "/" + toInsert);
                Console.WriteLine("Time taken: " + clock.ElapsedMilliseconds);
            }
    
            public class SameHash : EqualityComparer<int[]>
            {
                public override bool Equals(int[] p1, int[] p2)
                {
                    return p1[0] == p2[0] && p1[1] == p2[1];
                }
                public override int GetHashCode(int[] i)
                {
                    return base.GetHashCode();
                    //return i[0] * 10000 + i[1];
                    //Notice that this is a very basic implementation of a HashCode function
                    //in this case, it works perfect (no collisions) for numbers smallers than 10000
                }
            }
    
        }
    }

    using System;
    using System.Linq;
    
    namespace Bob
    {
        public static class Extensions
        {
            public static bool In<T>(this T toCheck, params T[] isItInOneOfThese)
            {
                return isItInOneOfThese.Contains(toCheck);
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                var ctrName = "";
                var ctr = "BT";
    
                if (ctr.In("BT", "B"))
                {
                    ctrName = "Brian";
                }
                else if (ctrName.In("G", "GD"))
                {
                    ctrName = "Brian";
                }
                Console.WriteLine(ctrName);
                Console.ReadLine();
            }
        }
    }

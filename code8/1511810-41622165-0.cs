    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        internal class Largest
        {
            private static double[] a1 = {15, 7, 8};
            private static double[] a2 = {10, 5, 14, 3};
    
            private static void Main(string[] args)
            {
                var arrayWithlargestElement = HasLargestElement(a1,a2);
                Console.Write(string.Join(Environment.NewLine, arrayWithlargestElement));
                Console.ReadKey();
            }
            
            public static double[] HasLargestElement(double[] a1, double[] a2)
            {
                return a1.Max() > a2.Max() ? a1 : a2;
            }
        }
    }

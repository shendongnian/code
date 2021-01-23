    using System;
    
    namespace ReferenceType
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Vector x, y;
                x = new Vector();
                x.GetterSetter= 30;
                Console.WriteLine(y.GetterSetter);
                y.GetterSetter= 50;
                Console.WriteLine(x.GetterSetter);
            }
        }
    }

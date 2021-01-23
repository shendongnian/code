    using System;
    
    namespace ReferenceType
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Vector x, y;
                x = new Vector();
                // Assign integer value to our public property "GetterSetter"
                x.GetterSetter= 30;
                // Access value of "Value" via "GetterSetter" property
                Console.WriteLine(y.GetterSetter);
                y.GetterSetter= 50;
                Console.WriteLine(x.GetterSetter);
            }
        }
    }

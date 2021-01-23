    using System;
    
    namespace ReferenceType
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Vector x, y;
                x = new Vector();
                x.Value = 30;
                Console.WriteLine(y.Value);
                y.Value = 50;
                Console.WriteLine(x.Value);
            }
        }
    }
    
    //Vector.cs
    using System;
    
    namespace ReferenceType
    {
        public class Vector
        {
            private int _value;
    
            public int Value{
                get { return _value; }
                set { _value = value; }
            }
        }
    }

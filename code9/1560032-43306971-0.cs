    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Test();
            }
        }
        public class Test
        {
            //[][] of Objects
            private MyObject[][] jaggedArray = new MyObject[3][]
            {
                new MyObject[5]
                {
                    new MyObject(), new MyObject(), new MyObject(), new MyObject(), new MyObject(),
                },
                new MyObject[5]
                {
                    new MyObject(), new MyObject(), new MyObject(), new MyObject(), new MyObject(),
                },
                new MyObject[5]
                {
                    new MyObject(), new MyObject(), new MyObject(), new MyObject(), new MyObject(),
                },
            };
            public Test()
            {
                jaggedArray = jaggedArray.Select(x => x.OrderBy(y => y).ToArray()).ToArray();
            }
        }
        public class MyObject : IComparable<MyObject>
        {
            public MyObject()
            { 
                Value = rand.Next(100);    
            }
            public int Value{ get; set; }
            static Random rand = new Random();
            public int CompareTo(MyObject o)
            {
                return this.Value.CompareTo(o.Value);
            }
        }
    }

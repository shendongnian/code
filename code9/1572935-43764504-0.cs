    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        public class Program
        {
            public enum MyEnum { Item1, Item2, Item3 }
            public class MyObject
            {
                public List<MyEnum> myEnums;
                public MyObject(List<MyEnum> myEnums)
                {
                    this.myEnums = myEnums;
                }
            }
    
    
            static void Main(string[] args)
            {
                List<MyEnum> myEnums1 = new List<MyEnum> { MyEnum.Item1, MyEnum.Item2 };
                List<MyEnum> myEnums2 = new List<MyEnum> { MyEnum.Item1 };
                List<MyEnum> myEnums3 = new List<MyEnum> { MyEnum.Item3 };
    
                List<MyObject> myObjects = new List<MyObject>();
    
                myObjects.Add(new MyObject(myEnums1));
                myObjects.Add(new MyObject(myEnums2));
                myObjects.Add(new MyObject(myEnums3));
    
    
    
                List<MyEnum> myEnumsFind = new List<MyEnum> { MyEnum.Item1, MyEnum.Item2 };
    
                var result = myObjects.Where(x => myEnumsFind.Any(y => x.myEnums.Contains(y))).ToList();
    
            }
        }
    }

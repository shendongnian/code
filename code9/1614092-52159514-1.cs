    using System;
    using System.Collections.Generic;
    
    namespace SwapArrayVal
    {
        class A
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
    
                List<A> list = new List<A>();
                list.Add(new A() { ID = 1, Name = "Pradeep" });
                list.Add(new A() { ID = 2, Name = "Binod" });
    
    
                IEnumerable<A> en1 = list;
    
    
                List<A> list2 = new List<A>();
                list2.Add(new A() { ID = 1, Name = "Pradeep" });
                list2.Add(new A() { ID = 2, Name = "Binod" });
    
    
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string outputOfInts = serializer.Serialize(list);
                string outputOfFoos = serializer.Serialize(list2);
    
    
    
                IEnumerable<A> en2 = list2;
                if (outputOfInts == outputOfFoos)
                {
                    Console.Write("True");
                }
    
                Console.ReadLine();
            }
        }
    }

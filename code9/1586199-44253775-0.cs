    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<LinqTest> myList = new List<LinqTest>();
                myList.Add(new LinqTest() { Id = 1, Value = "a" });
                myList.Add(new LinqTest() { Id = 1, Value = "b" });
                myList.Add(new LinqTest() { Id = 2, Value = "c" });
            
                var distinct = myList.Distinct().ToList();
            }
            class LinqTest
            {
                public override bool Equals(object obj)
                {
                    var that = obj as LinqTest;
                    return that == null ? false : Id == that.Id;
                }
                public override int GetHashCode()
                {
                    return Id;
                }
                public int Id { get; set; }
                public string Value { get; set; }
            }
        }
    }

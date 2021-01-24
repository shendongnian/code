    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace MyApplication
    {
    
        class ArrayLess : IEnumerable<string>
        {
    
            SortedList<string, dynamic> list = new SortedList<string, dynamic>();
    
            // Will need to update global list of array_values
            // This will be a proper array
            public void Add(dynamic key, dynamic val)
            {
                list[key.ToString()] = val;
            }
    
            // Could be int in which case need a list that isn't a sortedList?
            public dynamic this[dynamic key]
            {
                get { return list[key.ToString()]; }
            }
    
            public IEnumerator<string> GetEnumerator()
            {
                return this.list.Keys.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    
        static class Launcher
        {
            static void Main()
            {
                HelloWorld HW = new HelloWorld();
                HW.Test();
            }
        }
    
        class HelloWorld
        {
    
            // Define the variable and type
            ArrayLess resultSet;
    
            public void Test()
            {
    
                resultSet = new ArrayLess
                {
                    { "test", new ArrayLess() },
    
                    { 5, "Does this work?" }
                };
    
                resultSet["test"].Add("new", "value");
    
                Console.WriteLine(resultSet["test"]["new"]);
    
                Console.WriteLine(resultSet[5]);
    
                foreach (string key in resultSet)
                {
                    Console.WriteLine(key);
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace GenericValueCounter
    {
        public static class GenericHelper<T, U>
        {
            public static Dictionary<U, int> CountValues(Dictionary<T, IEnumerable<U>> dictionary)
            {
                var returnDict = new Dictionary<U, int>();
    
                foreach (var entry in dictionary)
                {
                    foreach (U value in entry.Value)
                    {
                        if (!returnDict.ContainsKey(value))
                        {
                            returnDict.Add(value, 1);
                            continue;
                        }
                        else
                        {
                            returnDict[value] = returnDict[value] + 1;
                        }
                    }
                }
    
                return returnDict;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var myDictionary = new Dictionary<int, IEnumerable<int>>();
                myDictionary.Add(1, new[] { 1, 2, 3, 4 });
                myDictionary.Add(2, new[] { 1, 2, 4 });
                myDictionary.Add(5, new[] { 1, 24 });
                myDictionary.Add(7, new[] { 1, 2, 3, 4 });
                myDictionary.Add(8, new[] { 1, 2, 3, 4 });
                myDictionary.Add(9, new[] { 1, 2, 3, 4 });
    
                var result = GenericHelper<int,int>.CountValues(myDictionary);
    
                foreach (var item in result)
                {
                    Console.WriteLine("Value:{0}, Count:{1}", item.Key, item.Value);
                }
                Console.ReadKey();
            }
    
            
        }
    }

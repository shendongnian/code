    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication55
    {
        class Program
        {
           
            static void Main(string[] args)
            {
               Dictionary<int, List<int>>  dict = new Dictionary<int,List<int>>() {
                                       {1,new List<int>(){1,1,2,3,3}},
                                       {2,new List<int> {1,1,1,2,3,3}}};
               foreach (int key in dict.Keys)
               {
                   List<int> numbers = dict[key];
                   List<int> uniqueNumbers = numbers.Distinct().ToList();
                   foreach(int uniqueNumber in uniqueNumbers)
                   {
                      Console.WriteLine("count of {0} for key {1} : {2}", key.ToString(), uniqueNumber, numbers.Where(x => x == uniqueNumber).Count()); 
                   }
               }
            }
      
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<string> list1 =new List<string>();
            list1.Add("%start : this is start : %End");
            list1.Add("%start : this is different : %End");
            list1.Add("%start : this is start 2: %End");
            List<string> list2 =new List<string>();
            list2.Add("%start : this is start 3: %End");
            list2.Add("%start : this is start : %End");
            list2.Add("%start : this is different : %End");
            List<string> list3 = list1.Union(list2).ToList();
            foreach(string item in list3){
                Console.WriteLine(item);
            }
        }
    }

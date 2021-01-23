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
                List<Items> items = Items.returnList("Food");
                var groups = items.GroupBy(x => x.name.Substring(0,1)).ToList();
               
            }
        }
        public class Items
        {
            public static List<Items> items = new List<Items>();
            public string name { get; set; }
            public string type { get; set; }
            public static List<Items> returnList(string type)
            {
                return items.Where(x => x.type == type).ToList();
            }
            
        }
    }

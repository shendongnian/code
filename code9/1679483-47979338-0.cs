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
                 var phones = new List<Phone> {
                    new Phone {Title="Galaxy S8", Company="Samsung", Price=60000 },
                    new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price=50000 },
                    new Phone {Title="Huawei P10", Company="Huawei", Price=10000 },
                    new Phone {Title="Huawe Mate 8", Company="Huawei", Price=29000 },
                    new Phone {Title="iPhone 7", Company="Apple", Price=38000 },
                    new Phone {Title="iPhone 6S", Company="Apple", Price=50000 }
                };
                 var groups = phones.GroupBy(x => x.Company);
                 foreach (var group in groups)
                 {
                     Console.WriteLine(group.Key);
                     foreach (Phone phone in group)
                     {
                         Console.WriteLine("Title : {0}", phone.Title);
                         Console.WriteLine("Price : {0}", phone.Price);
                         Console.WriteLine();
                     }
                 }
                 Console.ReadLine();
            }
        }
        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        } 
    }

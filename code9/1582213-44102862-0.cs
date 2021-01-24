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
                List<Purchase> purchases = new List<Purchase>();
                var results = purchases.GroupBy(x => x.ClientID.Id).Where(x => x.Sum(y => y.ItemID.Price) > 100).Select(x => x.FirstOrDefault().ClientID.Name).ToList();
            }
        }
        public class Client
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Item
        {
            public int Id { get; set; }
            public float Price { get; set; }
        }
        public class Purchase
        {
            public Client ClientID { get; set; }
            public Item ItemID { get; set; }
        }
    }

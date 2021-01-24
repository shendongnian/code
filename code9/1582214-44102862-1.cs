    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<Client> GetClients()
            {
                return new List<Client>
            {
                new Client {Id=1, Name="Jon" },
                new Client {Id=2, Name="Ben" },
                new Client {Id=3, Name="Tom" },
                new Client {Id=4, Name="Sara" },
            };
            }
            static List<Item> GetItems()
            {
                return new List<Item>
            {
                new Item {Id=1, Price = 8f },
                new Item {Id=2, Price = 8f },
                new Item {Id=3, Price = 75f },
                new Item {Id=4, Price = 33.33f },
                new Item {Id=5, Price = 82.5f },
                new Item {Id=6, Price = 25f },
            };
            }
            static List<Purchase> GetPurchases()
            {
                return new List<Purchase>
            {
                new Purchase(1,1),
                new Purchase(1,2),
                new Purchase(2,3),
                new Purchase(2,3),
                new Purchase(2,3),
                new Purchase(3,5),
                new Purchase(3,6),
                new Purchase(4,2),
                new Purchase(4,2),
                new Purchase(5,3),
                new Purchase(5,3),
                new Purchase(5,3),
                new Purchase(6,4),
                new Purchase(6,1)
            };
            }
            static void Main(string[] args)
            {
                List<Client> clients = GetClients();
                List<Item> items = GetItems();
                List<Purchase> purchases = GetPurchases();
                var results = (from p in purchases
                               join c in clients on p.ClientID equals c.Id
                               join i in items on p.ItemID equals i.Id
                               select new { purchase = p, client = c, item = i })
                              .GroupBy(x => x.client)
                              .Where(x => x.Sum(y => y.item.Price) > 100)
                              .Select(x => x.FirstOrDefault().client.Name)
                              .ToList();
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
            public int ClientID { get; set; }
            public int ItemID { get; set; }
            public Purchase(int item, int client)
            {
                ItemID = item;
                ClientID = client;
            }
        }
    }

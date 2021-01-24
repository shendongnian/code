    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication60
    {
        class Program
        {
            static void Main(string[] args)
            {
                int customerID = 1234;
                List<Order> CustomTypeA = Order.orders
                    .Where(x => (x.CustomerId == customerID) && (x.OrderType == "A") && (x.OrderStatus == "C")).ToList();
                var results = (from CustA in CustomTypeA 
                              join CustShip in Ship.CustomerShip on CustA.CustomerId equals CustShip.CustomerId 
                              select new { CustA = CustA, CustShip = CustShip})
                              .Where(x => (!RetailStore(x.CustShip.Address)) && (x.CustA.CustShip == x.CustShip.ShipSeq))
                              .OrderByDescending(x => x.CustShip.OrderDate)
                              .GroupBy(x => x.CustShip.ShipSeq)
                              .Select(x => x.FirstOrDefault())
                              .Select(x => new {
                                  CustomerID = x.CustShip.CustomerId,
                                  Address = x.CustShip.Address,
                                  OrderDate = x.CustShip.OrderDate
                              }).ToList();
            }
            static Boolean RetailStore(string address)
            {
                string pattern = "RETAIL.*STORE";
                return Regex.IsMatch(address, pattern);
            }
        }
        public class Order
        {
            public static List<Order> orders = new List<Order>();
            public int CustomerId { get; set; }
            public string OrderType { get; set; }
            public string CustShip { get; set; }
            public string OrderStatus { get; set; } 
        }
        public class Ship
        {
            public static List<Ship> CustomerShip = new List<Ship>();
            public int CustomerId { get; set; }
            public string ShipSeq { get; set; }
            public string Address { get; set; }
            public DateTime OrderDate { get; set; }
         }
    }

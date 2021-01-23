    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Product> Products = new List<Product>() {
                    new Product() { ProductName = "ABC", CategoryID = 1, SupplierID = 1},
                    new Product() { ProductName = "DEF", CategoryID = 1, SupplierID = 1},
                    new Product() { ProductName = "GHI", CategoryID = 1, SupplierID = 3},
                    new Product() { ProductName = "JKL", CategoryID = 1, SupplierID = 3},
                    new Product() { ProductName = "MNO", CategoryID = 2, SupplierID = 1},
                    new Product() { ProductName = "PQR", CategoryID = 3, SupplierID = 1},
                    new Product() { ProductName = "STU", CategoryID = 4, SupplierID = 1},
                    new Product() { ProductName = "VWX", CategoryID = 4, SupplierID = 1},
                    new Product() { ProductName = "YZ1", CategoryID = 4, SupplierID = 1},
                    new Product() { ProductName = "234", CategoryID = 5, SupplierID = 1}
                };
                var test1 = Products.GroupBy(x => new { supplier = x.SupplierID, category = x.CategoryID })
                    .Where(x => x.Count() >= 2).Select(y => y.Select(z => new { name = z.ProductName, supplier = y.Key.supplier, category = y.Key.category })).SelectMany(x => x).ToList();
                foreach (var item in test1)
                {
                    Console.WriteLine("Name = '{0}', Supplier = '{1}', Category = '{2}'", item.name, item.supplier, item.category);
                }
                Console.ReadLine();
            }
            
        }
        public class Product
        {
            public string ProductName { get; set; }
            public int CategoryID { get; set; }
            public int SupplierID { get; set; }
        }
    }

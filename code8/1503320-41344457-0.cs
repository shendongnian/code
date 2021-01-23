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
                List<Product> Products = new List<Product>();
                var test1 = Products.GroupBy(x => new { supplier = x.SupplierID, category = x.CategoryID })
                    .Where(x => x.Count() >= 2).Select(y => y.Select(z => new { name = z.ProductName, supplier = y.Key.supplier, category y.Key.category })).SelectMany(x => x).ToList();  
            }
            
        }
        public class Product
        {
            public string ProductName { get; set; }
            public int CategoryID { get; set; }
            public int SupplierID { get; set; }
        }
    }

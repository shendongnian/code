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
                ProductTransaction.productList = new List<ProductTransaction>() {
                   new ProductTransaction () {product="sword", date_sold= DateTime.Parse("03/05/2017"),category="weapons"},
                   new ProductTransaction() {product="sword2", date_sold=DateTime.Parse("03/01/2017"),category="weapons"},
                   new ProductTransaction() {product="potion", date_sold=DateTime.Parse("02/05/2017"),category="life"},
                   new ProductTransaction() {product="jacket", date_sold=DateTime.Parse("02/03/2017"),category="clothing"},
                   new ProductTransaction() {product="jacketofBear", date_sold=DateTime.Parse("02/01/2017"),category="clothing"}
                };
                var results = ProductTransaction.productList
                    .Where(x => (x.date_sold >= DateTime.Parse("1/1/2017")) && (x.date_sold <= DateTime.Parse("3/31/2017")))
                    .GroupBy(x => x.date_sold.Month)
                    .Select(x => new
                    {
                        month = x.Key,
                        year = x.FirstOrDefault().date_sold.Year,
                        category_count = x.GroupBy(y => y.category).Count(),
                        product_count = x.Count()
                    }).ToList();
            }
        }
        class ProductTransaction
        {
            public static List<ProductTransaction> productList = new List<ProductTransaction>();
            public string product;
            public DateTime date_sold;
            public string category;
        }
    }

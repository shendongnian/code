    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace TestingProduct
    {
        class TestingProduct
        {
            public class Product
            {
                public string ProductName { get; set; }
                public int InStock { get; set; }
                public double Price { get; set; }
                public string[] AvailableVariants { get; set; }
    
                public override string ToString() => $"{ProductName},{InStock},{Price}{(AvailableVariants?.Length > 0 ? "," + string.Join(",", AvailableVariants) : "")}";
    
                public static Product Parse(string csvRow)
                {
                    var fields = csvRow.Split(',');
    
                    return new Product
                    {
                        ProductName = fields[0],
                        InStock = Convert.ToInt32(fields[1]),
                        Price= Convert.ToDouble(fields[2]),
                        AvailableVariants = fields.Skip(3).ToArray()
                    };
                }
            }
    
            static void Main()
            {
                var prod1 = new Product
                {
                    ProductName = "test1",
                    InStock= 2,
                    Price = 3,
                    AvailableVariants = new string[]{ "variant1", "variant2" }
                };
    
                var filepath = @"C:\temp\test.csv";
                File.WriteAllText(filepath, prod1.ToString());
    
                var parsedRow = File.ReadAllText(filepath);
                var parsedProduct = Product.Parse(parsedRow);
                Console.WriteLine(parsedProduct);
    
                var noVariants = new Product
                {
                    ProductName = "noVariants",
                    InStock = 10,
                    Price = 10
                };
    
                var prod3 = new Product
                {
                    ProductName = "test2",
                    InStock= 5,
                    Price = 5,
                    AvailableVariants = new string[] { "variant3", "variant4" }
                };
    
                var filepath2 = @"C:\temp\test2.csv";
                var productList = new List<Product> { parsedProduct, prod3, noVariants };
                File.WriteAllText(filepath2, string.Join("\r\n", productList.Select(x => x.ToString())));
    
                var csvRows = File.ReadAllText(filepath2);
    
                var newProductList = new List<Product>();
                foreach (var csvRow in csvRows.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                {
                    newProductList.Add(Product.Parse(csvRow));
                }
                newProductList.ForEach(Console.WriteLine);
    
                Console.ReadKey();
            }
        }
    }

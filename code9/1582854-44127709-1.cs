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
                List<Ap21Stock> stock = new List<Ap21Stock>();
                List<Product> products = new List<Product>();
                var results = from s in stock
                              join p in products on string.Join(".", new string[] { s.ProductId.ToString(), s.StyleCode, s.ColourCode }) equals p.SellerSku
                              where s.FreeStock != p.Quantity 
                              select new { id = s.ProductId, sku = p.SellerSku };
            }
        }
        public class Ap21Stock
        {
            public int ProductId { get; set; }
            public string StyleCode { get; set; }
            public string ColourCode { get; set; }
            public string SizeCode { get; set; }
            public int FreeStock { get; set; }
        }
        public class Product
        {
            public string SellerSku { get; set; }
            public string ShopSku { get; set; }
            public int Quantity { get; set; }
            public int FulfillmentByNonSellable { get; set; }
        }
    }

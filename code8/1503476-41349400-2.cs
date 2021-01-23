    using System;
    using System.Collections.Generic;
    namespace SuperMarcado
    {
    internal class ShoppingCart
    {
        internal int printY;
        internal List<Product> productList;
        public ShoppingCart()
        {
            productList = new List<Product>();
        }
        internal void Display()
        {
            if (productList.Count == 0)
                Console.WriteLine("------------------ EMPTY CART------------------ ");
            
            foreach (var prod in productList)
                Console.WriteLine(prod.Name + " value: " + prod.Value);
        }
        internal void AddProduct(Product product)
        {
            productList.Add(product);
        }
    }
    }

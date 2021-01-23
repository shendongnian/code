    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace SuperMarcado
    {
    class MainClass
    {
        public static void Main(string[] args)
        {
            ShoppingCart myCart = new ShoppingCart();
            Product[] shopProducts = new Product[]
            {
                new Product("Cheese", 6, "Milk Cheese", "3/12/2016", 4),
                new Product("Bread", 2, "Grain Bread", "27/11/2016", 8),
                new Product("Ice Cream", 10, "Ice Cream", "09/11/2001", 1),
                new Product("Cookies", 100, " Chocolate Cookies", "00/00/0000", 5),
                new Product("Biscuits", 0.25f, "Vanila ", "08/01/2006", 6)
            };
            Shop shop = new Shop(shopProducts);
            shop.DisplayProducts();
            Console.WriteLine("------------------------------------------------------------");
            myCart.printY = Console.CursorTop;
            myCart.Display();
            ConsoleKeyInfo input;
            while ((input = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                if (!Char.IsDigit(input.KeyChar))
                    return;
                int index = Convert.ToInt16(input.KeyChar.ToString()) - 1;
                if (index < 1 || index > shop.products.Length)
                    return;
                myCart.AddProduct(shop.products[index]);
                shop.DecreaseAmount(shop.products[index]);
                shop.DisplayProducts();
                myCart.Display();
                //int userInput = 0;
                //do
                //{
                //    userInput = ShoppingCart();
                //} while (userInput != 5);
            }
        }
        //static public int ShoppingCart()
        //{
        //    Console.WriteLine("Your cart");
        //    Console.WriteLine();
        //    var result = Console.ReadLine();
        //    return Convert.ToInt32(result);
        //}
    }
    }

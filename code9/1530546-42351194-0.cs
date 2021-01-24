    class Program
    {
        static void Main(string[] args)
        {
            const int max_count = 10;
            string[] name = new string[max_count];
            int[] quantity = new int[max_count];
            decimal[] price = new decimal[max_count];
            decimal subtotal = 0;
            int count = 0;
            // Enter Values
            for(int i = 0; i<max_count; i++)
            {
                Console.Write("Item{0}", i+1);
                Console.Write("\tEnter Item Name: ");
                name[i]=Console.ReadLine();
                if(name[i].Length==0)
                {
                    break;
                }
                Console.Write("\tEnter Price: ");
                price[i]=decimal.Parse(Console.ReadLine());
                Console.Write("\tEnter Quantity: ");
                quantity[i]=int.Parse(Console.ReadLine());
                subtotal+=quantity[i]*price[i];
                count+=1;
            }
            // Display Summary
            Console.WriteLine("-------------------");
            Console.WriteLine("\nNumber of Items:{0}", count);
            Console.WriteLine("Subtotal is {0}", subtotal);
            decimal  tax=subtotal*0.065M;
            Console.WriteLine("Tax is {0}", tax);
            decimal total=tax+subtotal;
            Console.WriteLine("Total is {0}", total);
            Console.WriteLine("Thanks for shopping! Please come again.");
            Console.Read();
        }
    }

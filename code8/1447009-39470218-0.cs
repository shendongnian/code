    	public static void Main(string[] args)
        {
            Console.WriteLine("Write the price here  ");
            String text = Console.ReadLine();
            double price = Convert.ToDouble(text);
            Console.WriteLine("Write the amount here   ");
            text = Console.ReadLine();
            int quantity = Convert.ToInt32(text);
            double amount = price * quantity;
            double vat = amount * 0.25;
            double total = amount + vat;
            Console.WriteLine("{0, -15} {1, 10:F}", "Pris pa varen", price);
            Console.WriteLine("{0, -15} {1, 10:D}", "Antal styk", quantity);
            Console.WriteLine("{0, -15} {1, 10:F}", "Pris eks. moms", amount);
            Console.WriteLine("{0, -15} {1, 10:F}", "Moms", vat);
            Console.WriteLine("{0,  -15} {1, 10:F}", "Total pris inkl. moms", total);
    
    }

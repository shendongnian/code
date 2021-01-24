	using System;
	namespace ConsoleApp1
	{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Your Receipt");
			Console.WriteLine("");
			Console.WriteLine("");
			decimal count;
			decimal price;
			decimal subtotal = 0m; //subtotal is needed to be initialized from 0
			decimal tax;
			decimal total;
			count = 1;
			do
			{
				Console.Write("Item {0} Enter Price: ", count);
				++count;
				price = Convert.ToDecimal(Console.ReadLine());
                if (price != -1)  //if the console input -1 then we dont want to make addition
                  subtotal += price; 
			} while (price != -1);
			subtotal = Convert.ToInt32(price);
			Console.Write("Subtotal: ${0}", subtotal); //now subtotal will print running total
		}
	}
	}

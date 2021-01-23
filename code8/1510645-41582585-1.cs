	foreach (char PizzaSize in PizzaSizes)
	{
		if (PizzaSize == PizzaSizeChar)
		{
			TotalPizzaPrice = (PizzaPrices[index] * NumOfPizzas);
			Console.WriteLine("Your {0} pizza would normally be {1}", PizzaSize, PizzaPrices[index].ToString("C"));
			Console.WriteLine("Your total would {0}", TotalPizzaPrice.ToString("C"));
		}
		index++;
	}

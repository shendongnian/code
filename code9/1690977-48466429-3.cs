	const double EXIT_CODE = 99999;
	public IEnumerable<Clerk> GetClerkData()
	{
		MyInputClass myInput = new MyInputClass();
		bool collectMoreData = true;
		while (collectMoreData) 
		{
			double clerkNumber = myInput.GetClerkNumber();
			if (clerkNumber.Equals(EXIT_CODE))
			{
				collectMoreData = false; //we could use a `break;` statement here instead of using the collectMoreData flag; personally I think the flag's simpler to understand for a beginner / less prone to trip you up
			}
			else
			{
				string clerkName = myInput.GetClerkName();
				var newClerk = new Clerk(clerkNumber, clerkName);
				for (int monthNumber = 1; monthNumber <=12; monthNumber++)
				{
					int monthlySales = myInput.GetClerkSales(clerkName, monthNumber);
					newClerk.SalesFigures.Add(monthNumber, monthlySales);
				}
				yield return newClerk;
			}
		}
	}

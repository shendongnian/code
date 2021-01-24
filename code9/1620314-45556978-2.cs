		bool isBalanceValid = false;
		decimal decOpeningBalance = 0;
		Console.Write("Please enter your opening balance: ");
		while ( ! isBalanceValid )
		{
			string openingbalance = Console.ReadLine();
			if ( ! decimal.TryParse(openingbalance, out decOpeningBalance) )
			{
				Console.WriteLine( "You must enter a valid decimal value, please try again" );
			}
			else
			{
				isBalanceValid = true;
			}
		}

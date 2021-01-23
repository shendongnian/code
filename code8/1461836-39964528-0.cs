    public static void GetID()
    {
        //id the user enters as input
        string enteredID = "";
        do
        {
            Console.Write("Please enter user ID: ");
            enteredID = Console.ReadLine();
			bool isFound = false;
            foreach (var customer in preferredCustomers)
            {
                if (customer.CustomerID == enteredID)
                {
					isFound = true;
					ShowCustromerInfo(custromer);
                    return;
				}
            }
			if (!isFound)
				Console.Write("ID does not exist. ");
        } while (true);
    }
	
	public static string ShowCustromerInfo(PreferredCustomer custromer)
	{
		Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}", 
		custromer.CustomerName, custromer.Address, custromer.Phone, custromer.CustomerID, custromer.CustomerID, custromer.CalcAmount(), custromer.OnEmailList == true ? "true" : "false");
	}

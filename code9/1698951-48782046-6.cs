    List<int> Num_Int_List = new List<int>();
    for (int i = 0; 5 > i; i++)
	{
		Console.Write((i + 1) + ". ");
		if (int.TryParse(Console.ReadLine(), out enteredNumber)
		{
			Num_Int_List.Add(enteredNumber);
		}
		else
		{
			Console.WriteLine("Sorry that was not an integer, try again please");
			i-- // here set the counter to the last step to allow the user to repeat the step
		}
	}

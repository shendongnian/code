    void Main()
    {
	    PlayerInfo();
    }
    static void PlayerInfo()
    {
		string inputName = string.Empty;
		
        // This will loop until inputName is longer than 2 characters
		while (inputName.Length < 2)
		{
			Console.Write("Type your name: ");
			inputName = Console.ReadLine();
		}
        // Now that inputName is longer than 2 characters it prints the result only once
        Console.WriteLine("Hello " + inputName + "!");
    }

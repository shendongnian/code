        Console.WriteLine("How many values are you entering");
	    string input = Console.ReadLine();
        int value = Convert.ToInt32(input);
        Console.WriteLine(value +" Please enter the values of the currencies you are converting.");
        decimal[] money = new decimal[value];
        for (int i = 0; i < money.Length; i++)
        {
            money[i] = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("i is: " + i);
        }

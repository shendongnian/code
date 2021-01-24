	static void Main(string[] args)
	{
		int SIZE = 10;
		int numEntries = 0;
		int[] array = new int[SIZE];
		Console.WriteLine("Enter up to " + SIZE.ToString() + " integer(s).");
		string input;
		int userInput;
		for (int i = 0; i < array.Length; i++)
		{
			bool valid = false;
			do
			{
				Console.Write("Enter integer #" + (i+1).ToString() + " or 0 to stop: ");
				input = Console.ReadLine();
				valid = int.TryParse(input, out userInput);
				if (!valid)
				{
					Console.WriteLine("Invalid entry!");
				}
			} while (!valid);
			if (userInput == 0)
			{
				break;
			}
			numEntries++;
			array[i] = userInput;
		}
		if (numEntries > 0)
		{
			int product = ArrayProduct(array, numEntries);
			Console.WriteLine("The product is " + product.ToString("n0") + ".");
		}
		else
		{
			Console.WriteLine("No entries were made!");
		}
		Console.Write("Press [Enter] to quit.");
		Console.ReadLine();
	}
	private static int ArrayProduct(int[] arr, int length)
	{
		int product = 1;
		if (length <= arr.Length)
		{
			for(int i = 0; i < length; i++)
			{
				product = product * arr[i];
			}
		}
		return product;
	}

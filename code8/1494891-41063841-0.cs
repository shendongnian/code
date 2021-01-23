	static void Main(string[] args)
	{
		string[] author = {"William Shakespear", "Mark Twain", "Jane Austin", "Charlotte Bronte", "Louisa May Alcott",
		"Lewis Carroll", "D.H. Lawrence", "Charles Dickens", "Lucy Maud Montgomery", "Alexander Dumas" };
		while (true)
		{
			Console.WriteLine("Please type in an Author: ");
			string name = Console.ReadLine();
			int location = linearUnsorted(author, name);
			if (location == -1)
			{
				Console.WriteLine("Author not found, please try another");
			}
			else
			{
				Console.WriteLine("{0} is located at {1} in the poll", name, location + 1);
				break;
			}
		}
		Console.ReadLine();
	}

    static void Main()
	{
		Console.Write("enter something: ");
		string B = Console.ReadLine();
		if (int.TryParse(B, out int A))
			Console.WriteLine($"Yay, user entered number {A}.");
		else
			Console.WriteLine($"Nay, user entered a boring string {B}.");
	}

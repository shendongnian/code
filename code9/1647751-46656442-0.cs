    static void Main(string[] args)
	{
		int squredNum = 0;
		int NumberToSquare = 0;
		Console.WriteLine("Please enter a number to square: ");
		if(int.TryParse(Console.ReadLine(), out NumberToSquare))
		{
			squredNum = SquareValue(NumberToSquare);
			Console.WriteLine("{0} squared is {1}", NumberToSquare, squredNum);
		}
		Console.ReadKey();
	}
	static int SquareValue(int numberToSquare)
    {
        return numberToSquare * numberToSquare;
    }

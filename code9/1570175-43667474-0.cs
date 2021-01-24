    static void SumofSquares()
    {
        int num;
        Console.Write("Enter an int: ");
        string input = Console.ReadLine();
        int.TryParse(input, out num);
        long result = Squares(num);
        Console.WriteLine("The sum of squares for {0} is {1}", num, result);
    }

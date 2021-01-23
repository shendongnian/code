    static void Main(string[] args)
    {
        int answer = 0;
        Console.WriteLine("What is 27 + 4?");
        answer = int.Parse(Console.ReadLine());
        if (answer == 31)
        {
            Console.WriteLine("Correct!");
        }
        else //I added this part for beauty reasons
        {
            Console.WriteLine("Incorrect!");
        }
        Console.Read();
    }

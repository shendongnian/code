    Random numGen = new Random();
    int num = numGen.Next(1, 101);
    Console.WriteLine("Guess the number between 1 and 100");
    Console.Write("Your answer: ");
    while(true) 
    {
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == num)
        {
            break;
        }
        if (answer > num)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("Higher");
        }
    }
    Console.WriteLine("Congratulations,the number was " + num);
    Console.WriteLine();

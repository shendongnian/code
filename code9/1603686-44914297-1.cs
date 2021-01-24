    int number;
    int sum = 0;
    for (int i = 0; i < 26; i++)
    {
        Console.Write("{0}=", (char)(i + (int)('a')));
        if (int.TryParse(Console.ReadLine(), out number))
            sum += number;
        else
            break;
    }
    Console.WriteLine("Sum: {0}", sum);

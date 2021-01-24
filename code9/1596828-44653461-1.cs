    for (int i = 1; i < number;i++)
    {
        string result = i + " ";
        if ( i % 3 == 0)
        {
            result += "Fizz";
        }
        if (i % 5 == 0)
        {
            result += "Buzz";
        }
        Console.WriteLine(result);
    }

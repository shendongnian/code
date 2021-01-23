    Console.WriteLine("Input a few numbers separated by a hyphen : ");
    string input = Console.ReadLine();
    string[] split = input.Split('-');
    // Think about what type this SHOULD be
    string temp = split[0];
    for (int i = 1; i < split.Length; i++)
    {
        // Considering the fact that temp is actually currently a string, why should this work?
        // It's pretty obvious what "1" + 2 would mean, but what would "dog" + 1 mean?
        temp++;
        Console.WriteLine(temp);
        // Consider the fact that these must be the same type to do "==" (or there must be an implicit typecast between them)
        if (temp == split[i])
        {
            Console.WriteLine("Consecutive");
        }
    }

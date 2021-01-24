    string input = Console.ReadLine();
    foreach (char c in input)
    {
        int digit = Convert.ToInt32(c);
        s += digit;
        p *= digit;
    }

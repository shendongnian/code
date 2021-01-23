    char a;
    do
    {
        Console.WriteLine("What one would you like to buy? A B C or D");
        a = Char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
    } while (!"ABCD".Contains(a));

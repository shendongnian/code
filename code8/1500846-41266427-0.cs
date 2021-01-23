    int n = 0;
    int sum = 0;
    string inp = null;
    while(inp != "end")
    {
        Console.Write("Numbers ");
        inp = Console.ReadLine();
        int num = 0;
        if (int.TryParse(inp, out num))
        {
            sum = sum + num;
            n++;
        }
    }
    int average = sum / n;
    Console.WriteLine(" " + average);
    Console.ReadLine();

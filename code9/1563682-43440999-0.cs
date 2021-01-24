    Console.WriteLine("Enter Target Value: 6");
    int total = 0;
    int target = 6;
    int i = 1;
    while (i <= 4)
    {
        Console.Write("Enter #{0}:\t", i);
        total += Convert.ToInt32(Console.ReadLine());
        i++;
    }
    while (total == target);
    Console.WriteLine("It took {0} inputs to take the sum to\t{1}",i, total);
    Console.ReadLine();

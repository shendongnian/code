    ArrayList Num = new ArrayList();
    Console.WriteLine("Enter 5 numbers");
    while (Num.Count < 5)
    {
        Console.Write((Num.Count + 1) + ". ");
        int result = 0;
        if (int.TryParse(Console.ReadLine(), out result))
        {
            Num.Add(result);
        }
        else
        {
            Console.WriteLine("Please enter a number!!");
        }
    }
    Num.Sort();
    Console.Write("Sorted numbers: ");
    foreach (int value in Num)
    {
        Console.Write(value + " ");
    }
    Console.ReadLine();
    ArrayList odd = new ArrayList();
    ArrayList even = new ArrayList();
    foreach (int value in Num)
    {
        if (value % 2 != 0)
        {
            odd.Add(value);
        }
        else
        {
            even.Add(value);
        }
    }
    Console.Write("Odd numbers: ");
    foreach (int number in odd)
    {
        Console.Write(number + " ");
    }
    Console.Write("Even numbers: ");
    foreach (int numbers in even)
    {
        Console.Write(numbers + " ");
    }
    Console.ReadLine();

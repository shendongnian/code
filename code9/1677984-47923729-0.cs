    List<int> numbers= new List<int>();
    int a;
    while(Int32.TryParse(Console.ReadLine().ToString(), out a))
    {
        if (a == 0)
            break;
        else
            numbers.Add(a);
    }
    Console.WriteLine(numbers.Max());
    Console.Read();

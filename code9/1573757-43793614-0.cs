    int sum = 0;
    for(int i = 1;i<=HowMany;i++)
    {
        Console.Write("Enter #{0}: ", i);
        int input = int.Parse(Console.ReadLine());
        sum += input;
    }
    Console.WriteLine("The Result : Sum = {0}", sum);

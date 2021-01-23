    int age = -1
    Console.WriteLine("Before entering the unknown, could you please confirm your age? ");
    while (age == -1)
    {
        if !(int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Please enter a valid age");
        }
    }

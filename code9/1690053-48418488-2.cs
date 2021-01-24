    Console.WriteLine("------no's greater than 20 and divisible by 4 ------------");
    for (i = 0; i < numbers.Count; i++)
    {
        if(numbers[i] >= 20 && numbers[i] % 4 == 0)
            Console.WriteLine(numbers[i]);
    }
    Console.ReadLine();

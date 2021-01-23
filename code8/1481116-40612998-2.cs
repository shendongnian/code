    for (i = 0; i <= MaxNumber; i += 2)
    {
        if (i % 2 == 0)
        {
            EvenNumbers = i;
        }
        Console.Write(EvenNumbers);
        if(i % 20 == 0){
            Console.WriteLine();
        }
    }

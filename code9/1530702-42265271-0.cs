    int limit = 20;
    for (var so = 1; so < limit; so++)
    {
        bool isPrime = false;
        for (var chia = 2; chia < so; chia++)
        {
            if (so % chia == 0)
            {
                isPrime = true;
                break;
            }
        }
        if (!isPrime)
            Console.WriteLine(so);
    
    }

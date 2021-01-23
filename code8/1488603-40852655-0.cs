    ...
    while (n != 0 && i < 10)
    {
        Console.WriteLine("Input number");
        n = double.Parse(Console.ReadLine());
        if (n % 1 == 0)
        {
            if(n != max && n != smax)
                checking(n, ref max, ref smax);
            i++;
        }
        else
        {
            smax =0;
            break;
        }
    }
    ...

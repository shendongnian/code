    foreach(var number in Enumerable.Range(1, 100))
    {
        if (number % 3 == 0)
        {
            if (number % 7 == 0)
            {
                Console.WriteLine("BlueSky");
            }
            else
            {
                Console.WriteLine("Blue");
            }
        }
        else if(number % 7 == 0)
        {
            Console.WriteLine("Sky");
        }
        else
        {
            Console.WriteLine(number);
        }
    }

    {    
        var min = 5;
        var max = 10;
        var array = new int[4];
        var count = 0;
        var total = 0;
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter between 5 and 10:");
            var correct = false;
            while (!correct)
            {
                var val = int.Parse(Console.ReadLine());
                if (val >= min && val <= max)
                {
                    Console.WriteLine("Right number...");
                    array[i] = val; //Add the value to the array
                    count++; //Increase count
                    total += val; //Add the value to total
                    correct = true; //Break the while loop
                }
                else
                {
                    Console.WriteLine("Wrong, enter between 5 and 10:");
                }
            }
        }
        Console.WriteLine($"The total of the values are: {total}");
        Console.ReadKey();
    }

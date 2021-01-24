    static void Main(string[] args)
    {
        // This array will hold three items:
        //  - totals[0] = numberTotal
        //  - totals[1] = squareTotal
        //  - totals[2] = cubeTotal
        var totals = new int[3];
            
        Console.WriteLine("number\t" + "square\t" + "cube");
        Console.WriteLine("-----------------------------");
        for (int number = 0; number <= 20; number += 2)
        {
            // Grab a copy of 'number' so we don't modify the loop variable
            var thisNumber = number;
            for(int powerIndex = 0; powerIndex < 3; powerIndex++)
            {
                // Write this number to screen
                Console.Write($"{0:n0}\t", thisNumber);
                // Add this number to the current number in 'power' index
                totals[powerIndex] += thisNumber;
                // Power up
                thisNumber *= number;
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------------");
        Console.WriteLine("{0:n0}\t{1:n0}\t{2:n0}\t", totals[0], totals[1], totals[2]);
            
        // Alternatively, if you're using C#6.0, you could write:
        Console.WriteLine($"{totals[0]:n0}\t{totals[1]:n0}\t{totals[2]:n0}\t");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

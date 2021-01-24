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
                Console.Write(thisNumber + "\t");
                // Add this number to the current number in 'power' index
                totals[powerIndex] += thisNumber;
                // Power up
                thisNumber *= thisNumber;
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------------");
        Console.WriteLine(totals[0] + "\t" + totals[1] + "\t" + totals[2]);
            
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

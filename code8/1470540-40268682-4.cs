        int dFirst;
        int iSecond;
        int iThird;
        Console.WriteLine("Enter a number betwen 1 and 10: ");
        dFirst = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter another number between 1 and 10: ");
        iSecond = Convert.ToInt32(Console.ReadLine());
        if (dFirst > iSecond)
        {
            Console.WriteLine("The first number is bigger than the second one you entered.");
        }
        else if (iSecond >= dFirst)
        {
            Console.WriteLine("These numbers are equal");
        }
        else if(iSecond >= dFirst)
                {
            iThird = dFirst <= iSecond; //this is the line from the question
            Console.WriteLine("The number is: " + iThird);
            Console.WriteLine();
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

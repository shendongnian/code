    int[]studentNumber = new int[10];
    Console.Write("enter student number: ");
    int numbersEntered = 0;
    while (numbersEntered < 10)
    {
        var input = Console.ReadKey();
        // If the input is not a number, then reject their input by
        // backing up one character, writing a blank space over their
        // entry, and then back up again so we can get the next key.
        if (input.KeyChar < '0' || input.KeyChar > '9')
        {
            Console.CursorLeft -= 1;
            Console.Write(" ");
            Console.CursorLeft -= 1;
            continue;
        }
        studentNumber[numbersEntered] = int.Parse(input.KeyChar.ToString());
        numbersEntered++;
    }

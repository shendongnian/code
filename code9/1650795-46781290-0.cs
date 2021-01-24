	int selectionInput = 0;
    bool validInput = false;
    while (validInput == false)
    {
        try
        {
            Console.Write("{0,30}", "Make a Selection >> ");
            validInput = int.TryParse(Console.ReadLine(), out selectionInput);
            if (validInput && (selectionInput < 0 || selectionInput > 9))
                validInput = false;
        }
        catch
        {
            Console.WriteLine("Invalid Choice - please select from 0 - 9");
        }
    }

    while (true)
    {   
        Console.Write("Please Enter The Cost, In Pennies, Of The Item You Have Purchased: (type x to quit)");
        inputcost = Console.ReadLine();
        // Check if the user wants to stop executing the program
        if(inputcost == "x") 
            break;
        // Check if it is a valid integer 
        bool result = int.TryParse(inputcost, out validcost);
        if (!result)
        {
            Console.WriteLine("You Cannot Enter Decimals (or strings). Please Enter A Valid Integer Value.");
        }
        else if (validcost > 100 || validcost < 1)
        {
            Console.WriteLine("invalid value.please enter a number between 1 and 100 ");
        }
        else
        {
            Console.WriteLine("Valid value");
            // other code block that works with the input number....
        }
    }

    {
        //Declare Variables
        int intEnterVariable;
        string strEnterVariable;
        int intResult;
        int intLimit = 999;
        //int Total Variable
        int intTotal=0;
        Console.WriteLine("Enter in a number");
        Console.WriteLine("When done, enter 999");
        strEnterVariable = Console.ReadLine();
        intEnterVariable = Convert.ToInt32(strEnterVariable);
        //Accept user input
        while (intEnterVariable != intLimit)
        {
            //Read user input
            Console.WriteLine("Enter another number");
            strEnterVariable = Console.ReadLine();
            intEnterVariable = Convert.ToInt32(strEnterVariable);
            intTotal = intTotal + intEnterVariable;
        }
        intResult = intTotal;
        Console.WriteLine("Result: {0}", intResult.ToString());
        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();
    }

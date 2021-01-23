    if (UserInput2.ToLower() == "yes") Console.WriteLine("How much would you like to withdraw?");
    // And that's the if statement done.
            {
                // This is not part of any if block
                string UserInput = Console.ReadLine();
                double UserInput3 = double.Parse(UserInput);
                TotalAmount = TotalAmount - UserInput3;
                Console.WriteLine("Thank you. Your new balance is {0:C} ", TotalAmount);
                Console.WriteLine("Anything else?");
                string UserInput4 = Console.ReadLine();
                if (UserInput4.ToLower() == "yes") Console.WriteLine("What do you want to do?");
                Console.WriteLine("1). Withdraw");
                Console.WriteLine("2). Deposit");
                Console.WriteLine("Use number key for selection");
                string UserInput5 = Console.ReadLine();
                if (UserInput5.ToLower() == "1") Console.WriteLine("How much would you like to withdraw?");
                else if (UserInput5.ToLower() == "2") Console.WriteLine("How much would you like to deposit?");
                string UserInput6 = Console.ReadLine(); //FIRST ERROR
            else //Compiler says "else?  There is no if to match this with!"

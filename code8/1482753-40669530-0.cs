        static void Main()
        {
             // `userInput` and `defaultInt` are only visible inside this function
             // so you won't have access to them in InputCheck() unless you pass them in as parameters ...
             int userInput = -1;  //user enters int with ReadLine
             int defaultInt = 3; //user keys anything other than 3 through 10
             bool ok = false;       // flag to keep you in the while loop until the userInput is acceptable
             while (!ok)    // while we are *not* ok - the while-condition is checked at the top of the while-loop
             {
                 // Give user a chance to fix `userInput` inside the while loop
                 Console.WriteLine("Enter an Integer from 3 to 10");    // let the user know what the valid inputs are
                 userInput = int.Parse(Console.ReadLine());             // need to fix!! if user enters non-integer, eg "quit", this will throw an exception
                 ok = InputCheck(userInput);
                 // You have a choice here:
                 // You can keep looping until user specifies a number from 3 to 10
                 // Or you can simply override a bad choice with your default.
                 // If you don't want the default logic, get rid of the following block
                 if ( !ok )
                 {
                     // Let the user know what you're doing
                     Console.WriteLine("Overriding your invalid choice {0} to {1}", userInput, defaultInt);
                     userInput = defaultInt;    // override user's choice
                     ok = true;                 // force the while loop to exit
                 }
             }
             Console.WriteLine("The number you have chosen is {0}", userInput);
        }
        // Move the while loop out of `InputCheck` function.
        // InputCheck now has only one job - to check that userInput is acceptable
        public bool InputCheck(int userInput)    // you have to pass `userInput` in as parameter - it is only visible in Main()
        {
            if (3 <= userInput && userInput <= 10)
                return true;
            else
                return false;
        }
    }

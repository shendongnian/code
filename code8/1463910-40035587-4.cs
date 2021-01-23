    private static void Number()
        {   
            
            Console.Write("Type the number: ");
            string userInput = Console.ReadLine();
            int result;
            bool isValidNumber = Int32.TryParse(userInput,out result);
            (!isValidNumber)?
            Console.WriteLine("Entered value is not a vald number, so please type a number!"):
            Console.WriteLine("Hi, You have entered a valid number");
            Console.ReadLine();
        }

            string userInput;
            char userChar;
            do
            {
                Console.WriteLine("Please enter your input");
                userInput = Console.ReadLine();                
                // Could ensure valid input (Q, B, C, D, A) in the loop conditions if you wanted 
            } while (userInput.Length != 1);
            // Turn the string into an array of characters. Since we already checked the length we know input is at index 0
            char[] userStringToChar = userInput.ToCharArray();
            // Get the first character out of that array
            userChar = char.ToUpper(userStringToChar[0]);
            switch (userChar)
            {
                // insert cases
            }

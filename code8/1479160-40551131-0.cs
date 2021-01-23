        /// <summary>
        /// Slightly over-engineered :)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string rawInput;
            while (true)
            {
                rawInput = ReadPin();
                // No need to attempt parsing to an integer, as the PIN isn't stored as an integer
                bool isValid = Securityish.ValidatePin(rawInput);
                // If user has entered a valid PIN, break out of the loop ...
                if (isValid)
                    break;
                // ... otherwise let them know that they're entered an invalid or incorrect PIN
                Console.WriteLine("That value is incorrect...");
            }
            Console.WriteLine("Unlocked, press any key to continue");
            Console.Read();
        }
        /// <summary>
        /// Reads user input and masks to prevent accidental disclosure of the user's PIN
        /// </summary>
        /// <returns></returns>
        public static string ReadPin()
        {
            Console.Write("Please enter your PIN: ");
            string input = "";
            while (true)
            {
                // Read all key presses
                ConsoleKeyInfo key = Console.ReadKey();
                // If user has pressed enter, it's time to return the accumulated input, so bust out of this loop
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    // Allow deletion of PIN characters
                    if (input.Length > 0)
                    {
                        Console.Write(" \b");
                        input = input.Substring(0, input.Length - 1);
                    }
                    else
                    {
                        // The last character is a space, just put it back again then wait for further input
                        Console.Write(" ");
                    }
                    continue;
                }
                // Function keys etc. return a null character
                if (key.KeyChar == '\0')
                {
                    // Overwrite with a blank character, then move backwards to where we were in the first place
                    Console.Write("\b \b");
                    continue;
                }
                input += key.KeyChar;
                // Mask input
                Console.Write("\b*");
            }
            // Add blank line to keep input clean
            Console.WriteLine();
            return input;
        }
    }
    internal static class Securityish
    {
        /// <summary>
        /// Compares a supplied value against a secret PIN and returns whether the values match
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        internal static bool ValidatePin(string pin)
        {
            // Might be better to use one way hashing here
            return pin != null && pin.Equals(UnlockCode);
        }
        // TODO: Make this read a value from file, database, somewhere
        private static string UnlockCode { get { return "1111"; } }
    }

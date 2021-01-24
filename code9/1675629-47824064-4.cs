        /// <summary>
        /// Gets a strongly typed (double) value from the Console
        /// </summary>
        /// <param name="prompt">The initial message to display to the user</param>
        /// <returns>User input converted to a double</returns>
        public static double GetDoubleFromUser(string prompt = "Enter a number: ")
        {
            double value;
            // Write the prompt text and get input from user
            if (prompt != null) Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                // If input can't be converted to a double, keep trying
                Console.WriteLine("ERROR: Invalid value!");
                Console.Write(prompt);
            }
            // Return converted input value
            return value;
        }

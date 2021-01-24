    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Example
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                int entry = CollectUserInput<int>("Enter the number of times to print \"Yay!\": ",
                    (int x) => x > 0, "Please enter a positive number: ");
                for (int i=0; i<entry; i++) {
                    Console.Write("Yay!");
                }
            }
            /// <summary>
            /// Prompts user for console input; reprompts untils correct type recieved. Returns input as specified type.
            /// </summary>
            /// <param name="message">Display message to prompt user for input.</param>
            private static T CollectUserInput<T>(string message = null)
            {
                if (message != null)
                {
                    Console.WriteLine(message);
                }
                while (true)
                {
                    string rawInput = Console.ReadLine();
                    try
                    {
                        return (T)Convert.ChangeType(rawInput, typeof(T));
                    }
                    catch
                    {
                        Console.WriteLine("Please input a response of type: " + typeof(T).ToString());
                    }
                }
            }
            /// <summary>
            /// Prompts user for console input; reprompts untils correct type recieved. Returns input as specified type.
            /// </summary>
            /// <param name="message">Display message to prompt user for input.</param>
            /// <param name="validate">Prompt user to reenter input until it passes this validation function.</param>
            /// <param name="validationFailureMessage">Message displayed to user after each validation failure.</param>
            private static T CollectUserInput<T>(string message, Func<T, bool> validate, string validationFailureMessage = null)
            {
                var input = CollectUserInput<T>(message);
                bool isValid = validate(input);
                while (!isValid)
                {
                    Console.WriteLine(validationFailureMessage);
                    input = CollectUserInput<T>();
                    isValid = validate(input);
                }
                return input;
            }
        }
    }

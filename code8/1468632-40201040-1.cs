    using System;
    using System.Linq;
    namespace BMI_StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                PersonValidator inputValidator = new PersonValidator();
                Person person = new Person();
                person.Weight = CollectUserInput<double>("First, enter your weight in lbs: ",
                    inputValidator.IsValidWeight, "Please enter a positive number: ");
                person.Height = CollectUserInput<double>("\nGreat, now enter your height in inches: ",
                    inputValidator.IsValidHeight, "Please enter a positive number: ");
                double bmi = person.GetBmi();
                Console.WriteLine("\nPerfect! Your bmi is: {0:N2}. With just a few more inputs we'll have your bfp. ", +bmi);
                Console.Write("\nPress any key to continue");
                Console.ReadKey();
                person.Age = CollectUserInput<int>("According to _ your bfp is more accurate because it takes into account your age and gender. So enter your age first: ",
                    inputValidator.IsValidAge, "Please enter a positive, non-decimal number.");
                string sex = CollectUserInput<string>("\nGreat, now enter your sex, like this (male or female): ",
                    inputValidator.IsValidSex, $"That sex is not recognized. Please input one of: {string.Join(", ", Enum.GetNames(typeof(Person.BiologicalSex)).Select(x => x.ToLower()))}");
                person.Sex = inputValidator.ParseSex(sex).Value;
                double bfp = person.GetBfp();
                Console.WriteLine("Perfect! Your bfp is {0:N2} ", +bfp);
                Console.ReadKey();
            }
            /// <summary>
            /// Prompts user for console input; reprompts untils correct type recieved. Returns input as specified type.
            /// Option "message": Display message to prompt user for input. 
            /// </summary>
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
                        Console.WriteLine($"Please input a response of type: {typeof(T).ToString()}");
                    }
                }
            }
            /// <summary>
            /// Prompts user for console input. Returns input as specified type. 
            /// Option "message": Display message to prompt user for input.
            /// Option "validate": Prompt user to reenter input until it passes this validation function.
            /// Option "validationFailureMessage: Message displayed to user after each validation failure. 
            /// </summary>
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
        public class Person
        {
            public double Weight { get; set; }
            public double Height { get; set; }
            public int Age { get; set; }
            public BiologicalSex Sex { get; set; }
            private const int bmiVar = 703;
            public double GetBmi()
            {
                return ((Weight * bmiVar) /
                       (Math.Pow(Height, 2)));
            }
            public double GetBfp()
            {
                double bmi = GetBmi();
                switch (Sex)
                {
                    case BiologicalSex.MALE:
                        if (Age >= 13)
                        {
                            return (1.20 * bmi) - (0.23 * Age) - (10.8 * 1) - 5.4;
                        }
                        return (1.51 * bmi) - (0.70 * Age) - (3.6 * 1) + 1.4;
                    case BiologicalSex.FEMALE:
                        if (Age >= 13)
                        {
                            return (1.20 * bmi) - (0.23 * Age) - (10.8 * 0) - 5.4;
                        }
                        return (1.51 * bmi) - (0.70 * Age) - (3.6 * 0) + 1.4;
                    default:
                        throw new Exception($"No BFP calculation rule for sex: {Sex}");
                }
            }
            public enum BiologicalSex
            {
                MALE,
                FEMALE
            }
        }
        public class PersonValidator
        {
            public bool IsValidWeight(double weight)
            {
                return weight >= 0;
            }
            public bool IsValidHeight(double height)
            {
                return height >= 0;
            }
            public bool IsValidAge(int age)
            {
                return age >= 0;
            }
            public bool IsValidSex(string sex)
            {
                return ParseSex(sex) != null;
            }
            /// <summary>
            /// Attempts to parse sex from string. Returns null on failure.
            /// </summary>
            public Person.BiologicalSex? ParseSex(string sex)
            {
                int temp;
                bool isNumber = int.TryParse(sex, out temp);
                if (isNumber)
                {
                    return null;
                }
                try
                {
                    return (Person.BiologicalSex)Enum.Parse(typeof(Person.BiologicalSex), sex, ignoreCase: true);
                }
                catch (ArgumentException ex)
                {
                    return null;
                }
            }
        }
    }

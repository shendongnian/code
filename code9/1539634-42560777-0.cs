    namespace ConsoleApplication3
    {
        class Initiation difficulty
        {
            public static string name; // Here are your variables
            public static int diff;    // Now they're accessible across methods
            ...                        
            static void characterCreation()
            {
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
                Console.WriteLine("\nWelcome " + name + "!");
                ...
                ...
            }
            static void difficultyMenu()
            {
                Console.WriteLine("Please select a difficulty:\n1. Easy\n2. Medium\n3. Hard");
                diff = Convert.ToInt32(Console.ReadLine());
                ...
                ...
            }
        }
    }

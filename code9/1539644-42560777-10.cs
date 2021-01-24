    namespace ConsoleApplication3
    {
        class Initiation
        {
            public string name; // Here are your variables
            public int diff;    // Now they're accessible across the whole class
            ...                 
            void characterCreation()
            {
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
                Console.WriteLine("\nWelcome " + name + "!");
                ...
                ...
            }
            void difficultyMenu()
            {
                Console.WriteLine("Please select a difficulty:\n1. Easy\n2. Medium\n3. Hard");
                diff = Convert.ToInt32(Console.ReadLine());
                ...
                ...
            }
        }
    }

        static void Main(string[] args)
        {
            Console.WriteLine("What is your favourite fruit?, (Apples), (Bananas), (Kiwi) or (Peaches)?");
            string[] words = { "Apples", "Bananas", "Kiwi" }; // simple array declaration
            string input = Console.ReadLine();
            while (!words.Contains(input))
            {
                Console.WriteLine("Try Again!");
                input = Console.ReadLine();
            }
            Console.WriteLine(input + "!");
            Console.ReadKey(); // optional to let the User read the response
        }

    static void Main(string[] args)
            {
                Console.WriteLine("What is your favourite fruit?, (Apples), (Bananas), (Kiwi) or (Peaches)?");
                string[] words = new string[] { "Apple", "Bananas", "Kiwi" };
    
                string input = Console.ReadLine();
    
                while (!words.Contains(input))
                {
                    Console.WriteLine("Try Again!");
                    input = Console.ReadLine();
                }
                Console.WriteLine(input + "!");
            }

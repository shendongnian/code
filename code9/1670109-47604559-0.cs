     public class Program
    {
        public static void AskFirstQuestion()
        {
            Console.Clear();
            Console.WriteLine("Please choose a gender from the options below: ");
            Console.WriteLine("Male|Female|Random");
            Console.Write("Input: ");
            var gender = Console.ReadLine()?.ToUpper();
            if (gender == "MALE" || gender == "FEMALE")
            {
                HandleGenderSelection(gender);
            }
            else if (gender == "RANDOM")
            {
                HandleRandom();
            }
        }
        private static void HandleRandom()
        {
            var randomGender = GenerateRandomGender();
            Console.WriteLine($"The gender: {randomGender} was randomly chosen");
            Console.WriteLine("Is this the race you wish your character to be? Enter Yes/No: ");
            Console.Write("Input: ");
            var input = Console.ReadLine()?.ToUpper();
            switch (input)
            {
                case "YES":
                    Console.WriteLine("OK");
                    break;
                case "NO":
                    AskFirstQuestion();
                    break;
            }
        }
        private static string GenerateRandomGender()
        {
            //Have you logic to randomly create gender
            return "MALE";
        }
        private static void HandleGenderSelection(string gender)
        {
            Console.WriteLine("Is this the gender you wish your character to be? Enter Yes/No: ");
            Console.Write("Input: ");
            var input = Console.ReadLine()?.ToUpper();
            if (input == "YES")
            {
                Console.WriteLine("OK!");
            }
            else if (input == "NO")
            {
                AskFirstQuestion();
            }
        }
        static void Main(string[] args)
        {
            AskFirstQuestion();
        }
    }

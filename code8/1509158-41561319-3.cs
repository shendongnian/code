    class Program
    {
        // If you want to use CreateCharacter() to return a newly created character,
        // You could have CreateCharacter() return a Character
        public static Character CreateCharacter()
        {
            //Declare my variables
            string charName;
            int charBaseAttack;
            int charHealth;
            int charAge;
            int charSaiyanLevel;
            //Ask for user input
            Console.Write("Please enter the name of your character: ");
            charName = Console.ReadLine();
            Console.Write("Thanks for that, now enter a Base Attack level please:  ");
            charBaseAttack = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thanks for that, now enter a Health level please: ");
            charHealth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thanks for that, now how old is your character: ");
            charAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thanks for that, his or her Super Saiyan level please: ");
            charSaiyanLevel = Convert.ToInt32(Console.ReadLine());
            //Instantiate my person
            return new Character(charName, charBaseAttack, charHealth, charAge, charSaiyanLevel);
        }
        public static void Main(string[] Args)
        {
            // Two ways to instantiate a Character
            // 1. Change the return type of CreateCharacter() to return a Character object instead of void
            // 2. Copy & past the contents of CreateCharacter() into main
            //Declare my variables
            string charName;
            int charBaseAttack;
            int charHealth;
            int charAge;
            int charSaiyanLevel;
            //Ask for user input
            Console.Write("Please enter the name of your character: ");
            charName = Console.ReadLine();
            Console.Write("Thanks for that, now enter a Base Attack level please:  ");
            charBaseAttack = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thanks for that, now enter a Health level please: ");
            charHealth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thanks for that, now how old is your character: ");
            charAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thanks for that, his or her Super Saiyan level please: ");
            charSaiyanLevel = Convert.ToInt32(Console.ReadLine());
            //Instantiate my person
            Character userCharacter1 = new Character(charName, charBaseAttack, charHealth, charAge, charSaiyanLevel);
            System.Console.WriteLine();
            Character userCharacter2 = CreateCharacter();
            // Print both characters to the console
            System.Console.WriteLine();
            System.Console.WriteLine("First character stats:");
            System.Console.WriteLine(userCharacter1.ToString());
            System.Console.WriteLine();
            System.Console.WriteLine("Second character stats:");
            System.Console.WriteLine(userCharacter2.ToString());
        }
    }

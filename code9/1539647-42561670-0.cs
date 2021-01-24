    //use this new class as a container to pass multiple items back to the calling procedure
    public class Character {
         public string Name { get; set; }
         public int CharacterClass { get; set; }
         public int Diff { get; set; }
    }
    public class Initiation   //Pre-game stuff - Character name, class and game difficulty
    {
        static Character characterCreation()  //changed return type to Character to return object of Class Character
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nWelcome " + name + "!");
            Console.WriteLine("Please select a class:\n1. Warrior - Bonus damage with melee weapons, average health.\n2. Ranger - Reduced health, bonus damage with ranged weapons.\n3. Paladin - Low damage, bonus to health and armor.");
            int cclass = Convert.ToInt32(Console.ReadLine());
            switch (cclass)
            {
                case 1:
                    Console.WriteLine("You have chosen to be a Warrior, " + name + "!");
                    break;
 
                case 2:
                    Console.WriteLine("You have chosen to be a Ranger, " + name + "!");
                    break;
 
                case 3:
                    Console.WriteLine("You have chosen to be a Paladin, " + name + "!");
                    break;
 
                default:
                    Console.WriteLine("Incorrect entry, please enter 1, 2 or 3!");
                    break;
            }
            var character = new Character(); //build up the return Object
            character.Name = name;
            character.CharacterClass = cclass;
            character.Diff = Initiation.difficultyMenu();
            return character;
        }
 
        static int difficultyMenu()   //return type int so it returns the diff
        {
            do {
                Console.WriteLine("Please select a difficulty:\n1. Easy\n2. Medium\n3. Hard");
                int diff = Convert.ToInt32(Console.ReadLine());
                switch (diff)
                {
                    case 1:
                        Console.WriteLine("You have selected easy difficulty!");
                        break;
 
                    case 2:
                        Console.WriteLine("You have selected medium difficulty!");
                        break;
 
                    case 3:
                        Console.WriteLine("You have selected hard difficulty!");
                        break;
 
                    default:
                        Console.WriteLine("Incorrect entry! Please enter either 1, 2 or 3!");
                        break;
                }
            } while (diff<1 || diff >3)   // loop so program keeps asking until suitable input
            return diff; 
        }
 
 
 
 
        static void Main(string[] args)
        {
            Character character;
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Exit");
 
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    character = characterCreation();  //created character is now returned
                    Game game = new Game();
                    game.gameStart(character);
                    break;
 
                case 3:
                    Environment.Exit(0);
                    break;
 
                default:
                    Console.WriteLine("Incorrect entry, please enter 1 or 2!");
                    break;
 
            }
            Console.ReadLine();
 
 
        }
    }
 
    public class Game //Actual game
    {
        static void gameStart(Character character)
        {
 
 
        }
    }

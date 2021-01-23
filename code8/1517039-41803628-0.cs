    public class Character
    {       
       public int X { get; set; }
       public int Y { get; set; }
    }
    
    
    class MainClass
    {
        public static void Main (string[] args)
        {
            var hero = new Character {X = 42, Y = 36};
            Console.WriteLine(hero.X);
            Console.WriteLine(hero.Y);
            hero.X = 5;
            Console.WriteLine (hero.X);
        }
    }

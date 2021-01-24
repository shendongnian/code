    class Program 
    {
        private Positie position;
        static void Main(string[] args)
        {
            // Aanmaken van een positie-object
            Positie positie1 = new Positie(2, 3);
            // Aanmaken van een robot
            Console.WriteLine("1 ------------------------------------------");
            Robot robot1 = new Robot("Bart", positie1);
            // ----controles uitvoeren
            Console.WriteLine(robot1.Naam == "Bart");
            Console.WriteLine(robot1.Positie.X == 2);
            Console.WriteLine(robot1.Positie.Y == 3);
            Console.WriteLine(robot1.Richting == Richting.Boven);
            Console.WriteLine("11 ------------------------------------------");
            robot1.Stap();
            position = robot1.Positie; // <- this line
            robot1.Stap();
            robot1.Stap();
            robot1.Spoor.ToonSpoor();       // 2 - 3 -> 2 - 4 -> 2 - 5

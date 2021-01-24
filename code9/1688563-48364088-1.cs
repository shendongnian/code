    namespace project
    {
     class Program
     {
        public Player Player1{get;set;}
        static void Main(string[] args)
        {
            createPlayer();
            Console.WriteLine(player1.Name); //Doesn't exist in current context
            Console.ReadKey();
        }
        static public void createPlayer()
        {
            Console.WriteLine("\nType in your name :");
            player1 = new Player(Console.ReadLine());
        .
        .
        .
        }
    }

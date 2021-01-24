    namespace project
    {
     class Program
     {
        public static Player player1{get;set;}
        static void Main(string[] args)
        {
            createPlayer();
            Console.WriteLine(player1.Name); 
            Console.ReadKey();
        }
        public static void createPlayer()
        {
            Console.WriteLine("\nType in your name :");
            player1 = new Player(Console.ReadLine());
        .
        .
        .
        }
    }

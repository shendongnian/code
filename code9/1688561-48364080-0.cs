    static void Main(string[] args)
    {
        var player1 = createPlayer();
    
        Console.WriteLine(player1.Name);
        Console.ReadKey();
    }
    static public Player createPlayer()
    {
        Console.WriteLine("\nType in your name :");
        Player player1 = new Player(Console.ReadLine()); 
        Console.WriteLine("\n Name: " + player1.Name + "\n Speed: " + player1.Speed + "\n Defence: " + player1.Defence + "\n Damage: " + player1.Damage);
        Console.WriteLine("\nPress 1 to continue, Press 2 to reroll.");
    
        return player1;
    }

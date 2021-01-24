    public class Player
    {
        public int HP{get; set;}
        public Player()
        {
            HP = 100;
        }
    }
 
    ...
    public static void Main(string[] args)
    { 
        Player player = new Player();
        reduceHP(player);
        Console.WriteLine("HP: {0}, player.HP);
    }
    public static void reduceHP(Player player)
    {
        player.HP -= 10;
    }

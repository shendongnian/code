    static void Main(string[] args)
    {
        Map map = new Map();
        Player player = new Player();
        PrintMap(map, player);
    }
    
    static void PrintMap(Map map, Player player)
    {
        for (int i = 0; i < Map.ROWS; i++)
        {
            for (int j = 0; j < Map.COLUMNS; j++)
            {
                if (player.PositionX == i && player.PositionY == j)
                {
                    Console.Write('@');
                }
                else
                {
                    Console.Write(map.table[i, j]);
                }
            }
            Console.WriteLine();
        }
    }

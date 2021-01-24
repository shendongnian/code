    public static int GetNumberOfPlayers()
    {
        Console.Write("Enter number of players: ");
        int totalPlayers;
        while (!Int32.TryParse(Console.ReadLine(), out totalPlayers))
        {
            Console.WriteLine("Value must be numeric.");
        }
        return totalPlayers;
    }
    public static List<NameVariable> GetPlayerList(int num)
    {
        var list = new List<NameVariable>();
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine("Enter player {0}'s name:", i + 1);
            list.Add(new NameVariable
            {
                Name = Console.ReadLine(),
                ID = i
            });
        }
        return list;
    }
    public static void DisplayPlayers(List<NameVariable> list)
    {
        foreach(var player in list)
        {
            Console.WriteLine("Player {0}, Name: {1}", player.ID, player.Name);
        }
    }
    public static void CantThinkOfAGoodName()
    {
        while (true)
        {
            int totalPlayers = GetNumberOfPlayers();
            if (totalPlayers > 16 || totalPlayers < 12)
            {
                Console.WriteLine("Please enter a value between 12 and 16.");
            }
            else
            {
                var playerList = GetPlayerList(totalPlayers);
                DisplayPlayers(playerList);
                break;
            }
        }
    }
    public static void Main()
    {
        CantThinkOfAGoodName();
        Console.ReadLine();
    }

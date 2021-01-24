    public static void Main()
    {
		  Console.WriteLine("Write amount of players");
                int TotalPlayers = Convert.ToInt32(Console.ReadLine());
                List<NameVariable> PlayerList = new List<NameVariable>();
                for (int index = 0; index < TotalPlayers; index++) 
                {
                    Console.WriteLine("Enter player {0}'s name:", index + 1);
					PlayerList.Add(new NameVariable(){
						Name = Console.ReadLine(),
						Id = index
					});
                }
		
		foreach(var player in PlayerList)
		{
			Console.WriteLine(player.Name);
		}            
	}

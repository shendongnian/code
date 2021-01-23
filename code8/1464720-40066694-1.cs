	public class Player
	{
		public int Index { get; set; }
		public long Id { get; set; }
		public string Name { get; set; }
		
		public override string ToString()
		{
			return string.Format("Player(Index={0}, Id={1}, Name={2})", Index, Id, Name);
		}
	}
    public static Player ParsePlayer(string line)
	{
		var dot = line.IndexOf(".");
		var comma = line.LastIndexOf(",");
		return
			new Player
			{
				Index = int.Parse(line.Substring(0, dot).Trim()),
				Id = long.Parse(line.Substring(comma + 1).Trim()),
				Name = line.Substring(dot + 1, comma - (dot + 1)).Trim()
			};
	}
	
	public static void Main()
	{
		var data = new[] {
			"0. Yersinia Pestis, 76561198010013870",
			"1. CatharsisLtd., 76561198056110126",
			"2. Nut~Taco, 76561198072105032",
			"3. Smith, John, 76561198072105033",
			" 4.Allen, Paul,76561198072105034 "
		};
		
		var players = new List<Player>();
		
		// parse
		foreach (var line in data)
		{
			players.Add(ParsePlayer(line));
		}
		
		// check
		foreach (var player in players)
		{
			Console.WriteLine(player);
		}
	}

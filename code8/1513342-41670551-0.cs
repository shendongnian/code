    abstract class PlayerRank
    {
    	public DateTime Date { get; set; }
    	public int World { get; set; }
    	public int Player { get; set; }
    	public int Alliance { get; set; }
    	public int Rank { get; set;}
    }
    
    abstract class ApiRank
    {
    	public int Player { get; set; }
    	public int Alliance { get; set; }
    	public int Rank { get; set; }
    
        // method that should be overriden in
        // concrete class that create specific player rank type
        // as well as doing type specific operation
    	protected abstract PlayerRank CreatePlayerRank();
    	
        // put common operation here
    	public PlayerRank ToPlayerRank(int world, DateTime date)
    	{
    		var inst = CreatePlayerRank();
    
    		inst.Player = Player;
    		inst.Alliance = Alliance;
    		inst.Rank = Rank;
    		inst.World = world;
    		inst.Date = date;
    
    		return inst;
    	}
    }
    
    class PlayerUnitsKilledRank : PlayerRank
    {
    	public int UnitsKilled { get; set; }
    }
    
    class ApiCombatUnitsKilledRank : ApiRank
    {
    	public int UnitsKilled { get; set; }
    
    	protected override PlayerRank CreatePlayerRank()
    	{
    		var b = new PlayerUnitsKilledRank();
    		b.UnitsKilled = UnitsKilled;
    		return b;
    	}
    }
    
    class PlayerCavernRaidingRank : PlayerRank
    {
    	public int Plundered { get; set;}
    }
    
    class ApiRaidingCavernRank : ApiRank
    {
    	public int Plundered { get; set;}
    
    	protected override PlayerRank CreatePlayerRank()
    	{
    		var b = new PlayerCavernRaidingRank();
    		b.Plundered = Plundered;
    		return b;
    	}
    }
    
    static IEnumerable<PlayerRank> ConvertRank(IEnumerable<ApiRank> rankings, int world)
    {
    	DateTime now = DateTime.Now.Date;
    	return rankings.Select(x=>x.ToPlayerRank(world, now));
    }

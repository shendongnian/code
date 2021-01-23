    public interface IRank
    {
    	// Your common rank properties here
    	// Maybe even create a base abstract Rank class ...
    }
    
    public interface IRankProducer
    {
    	IRank ProduceRank();
    }
    
    public class PlayerCavernRaidingRank : IRank
    {
    }
    
    public class PlayerUnitsKilledRank : IRank
    {
    }
    
    public class ApiCombatUnitsKilledRank : IRankProducer
    {
    	public IRank ProduceRank()
    	{
    		return new PlayerUnitsKilledRank()
            {
                Player = this.Player,
                Alliance = this.Alliance,
                Rank = this.Rank,
                UnitsKilled = this.UnitsKilled
            };
    	}
    }
    
    public class ApiRaidingCavernRank : IRankProducer
    {
    	public IRank ProduceRank()
    	{
    		return new PlayerCavernRaidingRank()
            {
                Player = this.Player,
                Alliance = this.Alliance,
                Rank = this.Rank,
                Plundered = this.ResourcesPlundered
            };
    	}
    }
    
    public static IEnumerable<IRank> Convert(IEnumerable<IRankProducer> rankings, int world)
    {
        var dbRankings = new List<IRank>();
        DateTime now = DateTime.Now.Date;
        foreach (IRankProducer rank in rankings)
        {
    		var rank = rank.ProduceRank();
    		rank.World = world;
    		rank.Date = now;
            dbRankings.Add(rank);
        }
    	
        return dbRankings;
    }

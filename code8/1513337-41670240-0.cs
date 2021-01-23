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
                Date = now,
                World = world,
                Player = rank.Player,
                Alliance = rank.Alliance,
                Rank = rank.Rank,
                UnitsKilled = rank.UnitsKilled
            };
    	}
    }
    
    public class ApiRaidingCavernRank : IRankProducer
    {
    	public IRank ProduceRank()
    	{
    		return new PlayerCavernRaidingRank()
            {
                Date = now,
                World = world,
                Player = rank.Player,
                Alliance = rank.Alliance,
                Rank = rank.Rank,
                Plundered = rank.ResourcesPlundered
            };
    	}
    }
    
    public static IEnumerable<IRank> Convert(IEnumerable<IRankProducer> rankings, int world)
    {
        var dbRankings = new List<IRank>();
        DateTime now = DateTime.Now.Date;
        foreach (IRankProducer rank in rankings)
        {
            dbRankings.Add(rank.ProduceRank());
        }
    	
        return dbRankings;
    }

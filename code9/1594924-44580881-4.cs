    public interface IRoute
    {
        int GetLength(Station station1, Station station2);
    }
	public class Route : IRoute
	{
		private readonly IAgent _agent;
		
		public Route(IAgent agent)
		{
			if (agent == null) throw new ArgumentNullException("agent");
			_agent = agent;
		}
		public int GetLength(Station station1, Station station2)
		{
			var location1 = _agent.GetLocation(station1.StationCode);
			var location2 = _agent.GetLocation(station2.StationCode);
			
			result = location2.Position - location1.Position;
			return result;
		}
	}

    public abstract class Graph<T> // <-- Graph must be generic
    {
    	public Dictionary<Vector3, int> Dictionary { private set; get; }
    	public List<T> List { set; get; }
    
    	public Graph()
    	{
    		Dictionary = new Dictionary<Vector3, int>();
            // You could initialize the list as you did before, but it's cleaner to do it here
    		List = new List<T>();
    	}
    }
    
    public class Graph_Waypoints : Graph<Waypoint> // <-- Subclasses must provide the base class generic arguments
    {
    	public Graph_Waypoints() : base()
    	{
    	}
    }
    public class Graph_Tiles : Graph<Tile>
    {
    	public Graph_Tiles() : base()
    	{
    	}
    }

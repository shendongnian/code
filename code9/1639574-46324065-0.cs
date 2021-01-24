    public enum Cover
    {
    	Life,
    	Trauma
    }
    
    public enum MultiLife
    {
    	Multi,
    	Standard
    }
    
    public readonly Dictionary<Tuple<Cover, int, MultiLife>, int> Values
     = new Dictionary<System.Tuple<UserQuery.Cover, int, UserQuery.MultiLife>, int>
     {
     	[Tuple.Create(Cover.Life, 1, MultiLife.Standard)] = 78,
    	[Tuple.Create(Cover.Life, 1, MultiLife.Multi)] = 61,
    	[Tuple.Create(Cover.Life, 2, MultiLife.Standard)] = 71,
    	// [...]
     };

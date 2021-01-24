	static string lastGeneratedQuery;
	public static string LastGeneratedQuery
	{
		get
		{
			lock(_lock)
			{
				return lastGeneratedQuery;
			}
		}
		internal set
		{
			lock(_lock)
			{
				lastGeneratedQuery = value;
			}
		}
	}

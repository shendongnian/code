    public static IList<Enum> GetFlaggedValues(Enum flag) 
    {
		return Enum
			.GetValues(flag.GetType())
			.Cast<Enum>()
			.Where(e => e.HasFlag(flag))
			.ToList();
	}

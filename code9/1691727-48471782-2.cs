	public static void CallThem<TA, TB>()
		where TB : class, TA
	{
		Register<TA, TB>();			// Fine
		RegisterRestrictive<TA, TB>(); // CS0452
	}

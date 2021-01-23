	public static double ToUnixTicks(this DateTime dt)
	{
		DateTime d1 = new DateTime(1970, 1, 1);
		DateTime d2 = dt.ToUniversalTime();
		TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
		return ts.TotalMilliseconds;
	}

	public static class _myglobals
	{
        /// <summary> Helper function for declaring local variables inline. </summary>
		public static ref T local<T>(out T t)
		{
			t = default(T);
			return ref t;
		}
    };

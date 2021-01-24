    /// <summary>
	/// Returns a new array of (int,T) where each element of 'src' is paired with its index.
    /// </summary>
	public static (int Index, T Item)[] TagWithIndex<T>(this T[] src)
	{
		if (src.Length == 0)
			return new (int, T)[0];
		var dst = new (int Index, T Item)[src.Length];     // i.e, ValueTuple<int,T>[]
		ref var p = ref dst[0];      //  <--  co-opt element 0 of target for 'T' staging
		ref int i = ref p.Index;  //  <-- index field in target will also control loop
		i = src.Length;    
		while (true)
		{
			p.Item = src[--i];
			if (i == 0)
				return dst;
			dst[i] = p;
		}
	}

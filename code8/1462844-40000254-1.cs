	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long ReadInt64(byte* p)
	{
		int hi = ReadInt32(p);
		int lo = ReadInt32(p + 4);
		return (long)hi << 32 | (uint)lo;
	}
	

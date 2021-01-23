	public static Key RealKey(this KeyEventArgs e)
	{
		switch (e.Key)
		{
			case Key.System:
				return e.SystemKey;
			case Key.ImeProcessed:
				return e.ImeProcessedKey;
			case Key.DeadCharProcessed:
				return e.DeadCharProcessedKey;
			default:
				return e.Key;
		}
	}

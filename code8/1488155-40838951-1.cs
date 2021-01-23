	public int Length
	{
		get 
		{
            // Since we access the Stream property, the ObjectDisposedException
            // will be thrown when the class is disposed
			return this.Stream.Length;
		}
	}

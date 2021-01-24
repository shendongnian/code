	public static MessageBoxButton ReturnExtendedValue()
	{
		return (MessageBoxButton)6;
	}
	
	public static bool IsMessageBoxButtonThePrivatelyUsedExtraValue(MessageBoxButton value)
	{
		return value == (MessageBoxButton)6;
	}
	
	void Main()
	{
		Console.WriteLine(
			IsMessageBoxButtonThePrivatelyUsedExtraValue(
				ReturnExtendedValue())); // Prints "True"
	}

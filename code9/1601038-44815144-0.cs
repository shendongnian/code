	public static BasePage<T> Load<T>(this BasePage<T> page) where T : BasePage<T>
	{
		if (page.EvaluateLoad())
		{
			Console.WriteLine("It's true!");
			return page;
		}
		else
		{
			Console.WriteLine("It's false!");
			return null; // No need for default() here - default() of a reference type is
                         // always going to be null
		}
	}

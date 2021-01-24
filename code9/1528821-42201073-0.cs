		foreach(var dele in myEvent.GetInvocationList())
		{
			try
			{
				dele.DynamicInvoke();
			}
			catch(Exception e)
			{
				
			}
		}

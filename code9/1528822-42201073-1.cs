		foreach(var dele in myEvent.GetInvocationList())
		{
			try
			{
				dele.DynamicInvoke();
			}
			catch(Exception e)
			{
				//If possible, change the above type to be more specific
                //Also, do *something* here - at least log it somewhere
                //Empty catch blocks are evil to debug and reason about
			}
		}

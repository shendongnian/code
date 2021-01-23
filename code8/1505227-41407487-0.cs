	catch (AggregateException err)
	{
		foreach (var e in err.InnerExceptions)
		{
			exception = err.InnerException;
		}
	}

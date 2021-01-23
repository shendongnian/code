	IEnumerator enumerator2 = days.GetEnumerator();
	try
	{
		while (enumerator2.MoveNext())
		{
			Console.Write((string)enumerator2.Current + " ");
		}
	}
	finally
	{
		IDisposable disposable = enumerator2 as IDisposable;
		if (disposable != null)
		{
			disposable.Dispose();
		}
	}

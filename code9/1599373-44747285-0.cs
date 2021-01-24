	public static object[] AggregateInvoke(this Delegate del, params object[] args)
	{
		Delegate[] invlist = del.GetInvocationList();
		object[] results = new object[invlist.Length];
		for(int i = 0; i < invlist.Length; i++)
		{
			results[i] = invlist[i].DynamicInvoke(args);
		}
		return results;
	}
	
	public static TRet[] AggregateInvoke<TArg,TRet>(this Func<TArg, TRet> del, TArg arg)
	{
		Delegate[] invlist = del.GetInvocationList();
		TRet[] results = new TRet[invlist.Length];
		for(int i = 0; i < invlist.Length; i++)
		{
			results[i] = ((Func<TArg, TRet>)invlist[i]).Invoke(arg);
		}
		return results;
	}

    public static class X
    {
    	public static IObservable<T> AsyncFinally<T>(this IObservable<T> source, Func<Task> action)
    	{
    		return source
    			.Materialize()
    			.SelectMany(async n =>
    			{
    				switch (n.Kind)
    				{
    					case NotificationKind.OnCompleted:
    					case NotificationKind.OnError:
    						await action();
    						return n;
    					case NotificationKind.OnNext:
    						return n;
    					default:
    						throw new NotImplementedException();
    				}
    			})
    			.Dematerialize()
    		;
    	}
    }

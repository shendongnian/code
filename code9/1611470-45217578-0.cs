    public static class X
    {
    	public static IObservable<T> AsyncFinally<T>(this IObservable<T> source, Func<Task> action)
    	{
    		return source.Publish(_source => _source.Merge(_source
    			.IgnoreElements()
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
    					default:
    						throw new NotImplementedException();
    				}
    			})
    			.Dematerialize()
    		));
    	}
    }

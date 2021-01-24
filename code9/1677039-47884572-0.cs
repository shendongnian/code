	public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, Func<TResult> valueFunction) where TMock : class
	{
		return mock.Returns(() => Task.FromResult(valueFunction()));
	}
	public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, TResult value) where TMock : class
	{
		return mock.ReturnsAsync(() => value);
	}

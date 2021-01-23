    public static class AsyncExtensions
    {
        public static async Task<U> AsCpuBoundAsync<T,U>(this Func<T,U> func, T t) 
        {
            var task = new Task<U>( () => func(t));
			task.Start();
			return await task;   
        }
    }

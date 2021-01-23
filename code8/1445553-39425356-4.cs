    public static class AsyncExtensions
    {
        public static Task<U> AsCpuBoundAsync<T,U>(this Func<T,U> func, T t) 
        {
            return Task.Run(() => func(t));  
        }
    }

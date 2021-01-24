    public class AsyncHandler<T>
    {
        private string url;
    
        public AsyncHandler(string url)
        {
            this.url = url;
        }
        public static AsyncHandler<T> GetAsyncHandlerForRestApi(string url)
        {
            return new AsyncHandler<T>(url);
        }
        public static Task<T> GetAsyncHandler(string urlFormat, params object[] args)
        {
            string url = string.Format(urlFormat, args);
            return Task<T>.Run( () => { return GetAsyncHandlerForRestApi(url)});
        }
    }

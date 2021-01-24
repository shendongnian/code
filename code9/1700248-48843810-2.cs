    [OperationContract]
    [WebGet(UriTemplate = "Operation")]
    public async Task<bool> Operation()
        {
            RunWithOperationContext(()=> {
            await Task.Delay(1000); 
            return true;}
        }
    public static Task<TResult> RunWithOperationContext<TResult>(Func<TResult> function)
            {
                var context = HttpContext.Current;
                var result = await function();
                HttpContext.Current = context;
                return result;
            }

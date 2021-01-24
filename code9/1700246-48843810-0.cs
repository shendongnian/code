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
                return Task.Run(() => {
                    HttpContext.Current = context;
                    return function();
                });
            }

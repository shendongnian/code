    public class Executor
    {
        // IResponseProvider has the GetResponse method.
        // This interface can be mocked in test and can be injected in real environment.
        public IResponseProvider ResponseProvider { get; set; }
        public async T Execute<T>(Func<T> func)
        {
            var response = await ResponseProvider.GetResponse(query);
            // do something with response...
            return func();
        }
    }

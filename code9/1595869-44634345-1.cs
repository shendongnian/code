    public class AndroidSample : ISample
    {
        public Task<bool> GetABool()
        {
            // replace with however you get the value.
            var ret = true;
            return Task.FromResult(ret);
        }
    }

    public class SomeService : ISomeAsyncService<MyObject>
    {
        private static Dictionary<string, MyObject> _dictionary = new Dictionary<string, MyObject>();
        public async Task<MyObject> GetSomeObjectAsync(string id)
        {
            var obj = _dictionary["id"];
            return obj;
        }
    }

        public async Task<string> GetStringAsynchronously()
        {
             var str = await SomeOtherGetter();
             return str.Replace("foo", "bar"); // note: we need the actual string here
        }

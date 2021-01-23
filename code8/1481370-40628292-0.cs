    public class MyUserIdProvider : IUserIdProvider
    {
        private static IDictionary<string, Guid> _tokens;
        static MyUserIdProvider()
        {
            _tokens = new ConcurrentDictionary<string, Guid>();
        }
        private static string Key(IRequest request)
        {
            var key = request.QueryString["connectionToken"];
            return key;
        }
        public static string UserId(IRequest request)
        {
            return _tokens[Key(request)].ToString();
        }
        public string GetUserId(IRequest request)
        {
            var key = Key(request);
            _tokens[key] = Guid.NewGuid();
            return _tokens[key].ToString();
        }
    }

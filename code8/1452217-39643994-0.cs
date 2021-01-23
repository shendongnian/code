    static class Mediator
    {
        private static Dictionary<string, List<Action<Object>>> _tokenCallbacks = new Dictionary<string, List<Action<object>>>();
        internal static void Register(string token, Action<Object> callback)
        {
            token = token.ToLower();
            if (_tokenCallbacks.ContainsKey(token))
            {
                var l = _tokenCallbacks[token];
                var found = false;
                foreach (var existingCallback in l)
                {
                    if (existingCallback.Equals(callback))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) l.Add(callback);
            }
            else
            {
                var l = new List<Action<Object>>(new[] { callback });
                _tokenCallbacks.Add(token, l);
            }
        }
        internal static void NotifyColleagues(string callbackToken, Object args)
        {
            callbackToken = callbackToken.ToLower();
            if (_tokenCallbacks.ContainsKey(callbackToken)) _tokenCallbacks[callbackToken].ForEach((x) => x(args));
        }
    }

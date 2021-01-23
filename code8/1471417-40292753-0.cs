     public static class Ext
    {
        public static Task<string> RequestStringAsync(this IEventProvider cls)
        {
            var tcs = new TaskCompletionSource<string>();
            EventHandler<string> handler = null;
            handler = (o, s) =>
            {
                tcs.SetResult(s);
                cls.StringAvailable -= handler;
            };
            cls.StringAvailable += handler;
            cls.RequestString();
            return tcs.Task;
        }
    }

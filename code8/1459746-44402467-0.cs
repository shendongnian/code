        public static Task AsCompletedTask<T>(this Action<T> func, T arg)
        {
            var tcs = new TaskCompletionSource<VoidResult>();
            try
            {
                func(arg);
                tcs.SetResult(voidResult);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            };
            return tcs.Task;
        }

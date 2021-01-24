    public static class ControlAsyncExtensions
    {
        public static Task InvokeAsync(this Control control, Action action)
        {
            var tcs = new TaskCompletionSource<bool>();
            control.BeginInvoke(new Action(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
            ));
            return tcs.Task;
        }
        public static Task<T> InvokeAsync<T>(this Control control, Func<T> action)
        {
            var tcs = new TaskCompletionSource<T>();
            control.BeginInvoke(new Action(() =>
            {
                try
                {
                    tcs.SetResult(action());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
            ));
            return tcs.Task;
        }
    }

    public static class DispatcherHelper
    {
        public static Action<T> MakeInvoker<T>(
            this Dispatcher dispatcher,
            Action<T> action,
            DispatcherPriority priority = DispatcherPriority.Normal)
        {
            return o => dispatcher.BeginInvoke(priority, action, o);
        }
    }

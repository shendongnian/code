    class RetryExecutor
    {
        public static void Call(Action action)
        {
            var attribute = action.Method.GetCustomAttribute(typeof(Retry));
            if (attribute != null)
            {
                 ((Retry)attribute).Wrap(action);
            }
            else
            {
                action();
            }
        }
    }

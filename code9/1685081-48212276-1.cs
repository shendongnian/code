    public static class Ignore<TException> where TException : Exception
    {
        public static void ThrownFrom([InstantHandle][NotNull] Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
    
            try
            {
                action();
            }
            catch (TException ex)
            {
                // ignore
            }
        }
    }

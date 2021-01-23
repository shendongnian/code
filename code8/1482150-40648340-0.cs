    static void PerformInTryCatch<T, TException>(Action<T> action, T obj) where TException : Exception
        {
            try
            {
                action(obj);
            }
            catch (TException exception)
            {
                // Perform some logging   
            }
        }

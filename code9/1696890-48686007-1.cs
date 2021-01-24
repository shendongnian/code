           public void ExecuteWithRetry(bool IsRetryEnabled, params object[] args)
            {
                try
                {
                    _methodToRetry.DynamicInvoke(args);
                }
                catch (Exception ex)
                {
                    if (IsRetryEnabled)
                    {
                        // re execute method.
                        ExecuteWithRetry(false, args);

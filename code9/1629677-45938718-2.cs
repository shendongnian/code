    private bool FillProducts()
        {
            // To prevent waiting forever ...
            int retryCount = 10;
            bool isDone = false;
            while ( !isDone && (retryCount-- > 0) )
            {
                try
                {
                    /* ... Fails if no connection ... */
                }
                catch (Exception ex)
                {               
                    isDone = false;
                    // Just omit this! >>> ReconnectOnError(ex); // ==> BLOCKS !!
                }
            }
            return isDone;
        }

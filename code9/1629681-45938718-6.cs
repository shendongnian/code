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
                    // OnSuccess=>
                    isDone = true; // will break the loop.
                }
                catch (Exception ex) // You should actually catch a more specific Exception here
                                     // ... but that's a different question.
                {               
                    isDone = false;
                    // Just omit this! >>> ReconnectOnError(ex); // ==> BLOCKS !!
                    // If you want, you can add a little delay here ...
                    Thread.Sleep(1000);
                }
            }
            return isDone;
        }

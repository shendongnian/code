    private bool FillProducts()
        {
            bool isDone = false;
            try
            {
                /* ... Fails if no connection ... */
            }
            catch (Exception ex)
            {               
                isDone = false;
                ReconnectOnError(ex); // ==> BLOCKS !!
            }
            return isDone;
        }
        int count = 0;
        private void ReconnectOnError(Exception errorMessage)
        {
            try
            {
                Thread.Sleep(1000);
                if (count < 1)
                {
                    FillProducts();     // <== Will result in another call to this method. Returns on 1st Succeeding call to FillProducts.
                    Reconnect();        // <== Will be called as soon as FillProducts returns.
                }
                else
                {
                    Reconnect();
                }
            }
            catch (WebException ex)
            {
                ReconnectOnError(ex);
            }
        }

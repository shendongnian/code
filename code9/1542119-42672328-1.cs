    internal void ReadAll(CancellationTokenSource cts)
    {
         // [communication]
         
         if (cts.IsCancellationRequested)
         {
             ReadAllComplete?.Invoke(false);
         }
         else
         {
             ReadAllComplete?.Invoke(true);
         }
    }

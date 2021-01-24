    bool entered = await semaphore.WaitAsync(TimeSpan.Zero);
    if (entered) {
        try {
            HttpResponseMessage response = await Client.Proxy.PostAsJsonAsync(path, request);
        }
        finally {
            semaphore.Release();
        }
    }
    else {
        // Discarded: Another service call is in progress    
    }

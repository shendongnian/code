    IEnumerable<string> bunchOfHosts = GetBunchOfHosts();
    IList<IPHostEntry> result;
    using ( var limiter = new TimedSemaphoreSlim( 300, 300, TimeSpan.FromSeconds( 1 ) ) )
    {
        result = bunchOfHosts.AsParallel()
            .Select( e =>
            {
                limiter.Wait();
                try
                {
                    return Dns.GetHostEntry( e );
                }
                finally
                {
                    limiter.Release();
                }
            } )
            .ToList();
    }

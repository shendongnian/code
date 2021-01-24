    using ( var limiter = new RequestPerPeriodLimiter( 10, TimeSpan.FromSeconds( 1 ) ) )
    {
        for ( int i = 1; i <= 1000; i++ )
        {
            limiter.Wait();
            Console.WriteLine( "{0}: {1}", DateTime.UtcNow, i );
        }
    }

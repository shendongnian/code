    using (X509Certificate2 cert = new X509Certificate2("signedfile.exe"))
    {
        X509Chain chain = new X509Chain();
        chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid;
        bool validChain = chain.Build(cert);
        if (!validChain)
        {
            // Whatever you want to do about that.
            foreach (var status in chain.ChainStatus)
            {
                // In reality you can == this, since X509Chain.ChainStatus builds
                // an object per flag, but since it's [Flags] let's play it safe.
                if ((status.Status & X509ChainStatusFlags.PartialChain) != 0)
                {
                    // Incomplete chain.
                }
            }
        }
        X509Certificate2Collection chainCerts = new X509Certificate2Collection();
        foreach (var element in chain.ChainElements)
        {
            chainCerts.Add(element.Certificate);
        }
        // now chainCerts has the whole chain in order.
    }

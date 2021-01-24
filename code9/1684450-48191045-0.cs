    HashSet<X509Certificate2> s_allowedRoots = new HashSet<X509Certificate2>
    {
        trustedCertA,
        trustedCertB,
        ...
    };
    ...
    // In your callback
    if (errors != SslPolicyErrors.None)
    {
        return false;
    }
    X509Certificate2 chainRoot = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
    return s_allowedRoots.Contains(chainRoot);

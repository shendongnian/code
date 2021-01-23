    HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
    request.ServerCertificateValidationCallback = ValidationCallback;
    private static bool ValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Since you want to be more strict than the default, reject it if anything went wrong.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            return false;
        }
        // If the chain didn't suppress any type of error, and revocation
        // was checked, then it's okay.
        if (chain.ChainPolicy.VerificationFlags == X509VerificationFlags.None &&
            chain.ChainPolicy.RevocationMode == X509RevocationMode.Online)
        {
            return true;
        }
        X509Chain newChain = new X509Chain();
        // change any other ChainPolicy options you want.
        X509ChainElementCollection chainElements = chain.ChainElements;
        // Skip the leaf cert and stop short of the root cert.
        for (int i = 1; i < chainElements.Count - 1; i++)
        {
            newChain.ChainPolicy.ExtraStore.Add(chainElements[i].Certificate);
        }
        // Use chainElements[0].Certificate since it's the right cert already
        // in X509Certificate2 form, preventing a cast or the sometimes-dangerous
        // X509Certificate2(X509Certificate) constructor.
        // If the chain build successfully it matches all our policy requests,
        // if it fails, it either failed to build (which is unlikely, since we already had one)
        // or it failed policy (like it's revoked).        
        return newChain.Build(chainElements[0].Certificate);
    }

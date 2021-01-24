    public static bool ValidateServerCertificate(object sender,
                                             X509Certificate certificate,
                                             X509Chain chain,
                                             SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
         // Do not allow this client to communicate with unauthenticated servers.
         return false;
    }

    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, 
                                    X509Chain chain, SslPolicyErrors policyErrors)
    {
        bool result = false;
        if (cert.Subject.ToUpper().Contains("MY_CERT_ISSUER_NAME"))
        {
            result = true;
        }
        return result;
    }

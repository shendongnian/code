    static internal class SSLCertificateResolverConfigurator
    {
        static internal void Setup()
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }
        static private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors) //0
        {
            if (policyErrors == SslPolicyErrors.None)
                return true;
            var thumbprint = chain.ChainElements.Count > 0 ? chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint : null;
            if (thumbprint == null) //somethings wrong
                return false;
            var sha1CertHashString = certificate.GetCertHashString();
            if (sha1CertHashString == null) //somethings wrong
                return false;
            if (ApprovedCertificatesSHA1Cache.ContainsKey(sha1CertHashString))
                return true;
            try
            {
                var asCertificate2 = certificate as X509Certificate2 ?? new X509Certificate2(certificate);
                X509CertificateValidator.ChainTrust.Validate(asCertificate2); //1
                ApprovedCertificatesSHA1Cache.TryAdd(sha1CertHashString, sha1CertHashString);
                return true;
            }
            catch
            {
                return false;
            }
            //0 vital for signalr to work via https  https://stackoverflow.com/questions/44433067/signalr-could-not-establish-trust-relationship-for-the-ssl-tls-secure-channel
            //1 chaintrust checks both personal account specific certificates and the trusted root certificates authorities
        }
        static private readonly ConcurrentDictionary<string, string> ApprovedCertificatesSHA1Cache = new ConcurrentDictionary<string, string>();
    }
    

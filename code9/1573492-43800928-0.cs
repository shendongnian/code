    public static class CertificateValidator
    {
        public static string TrustedThumbprint { get; set; }
        public static bool ValidateSslCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors errors)
        {
            // Wrap certificate to access thumbprint.
            var certificate2 = new X509Certificate2(certificate);
            // Only accept certificate with trusted thumbprint.
            if (certificate2.Thumbprint.Equals(
                 TrustedThumbprint, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            // In all other cases, don't trust the certificate.
            return false;
        }
    }

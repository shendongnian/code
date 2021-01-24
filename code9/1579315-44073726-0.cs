    using System.Security.Cryptography.X509Certificates;
    ...
    private static X509Certificate2 MakeLocalhostCert()
    {
        using (ECDsa key = ECDsa.Create(ECCurve.NamedCurves.nistP384))
        {
            var request = new CertificateRequest(
                "CN=localhost",
                key,
                HashAlgorithmName.SHA384);
            request.CertificateExtensions.Add(
                new X509BasicConstraintsExtension(false, false, 0, true));
            const X509KeyUsageFlags endEntityTypicalUsages =
                X509KeyUsageFlags.DataEncipherment |
                X509KeyUsageFlags.KeyEncipherment |
                X509KeyUsageFlags.DigitalSignature |
                X509KeyUsageFlags.NonRepudiation;
            request.CertificateExtensions.Add(
                new X509KeyUsageExtension(endEntityTypicalUsages, true));
            var sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddDnsName("localhost");
            sanBuilder.AddIpAddress(IPAddress.Loopback);
            sanBuilder.AddIpAddress(IPAddress.IPv6Loopback);
            request.CertificateExtensions.Add(sanBuilder.Build());
            request.CertificateExtensions.Add(
                new X509EnhancedKeyUsageExtension(
                    new OidCollection
                    {
                        // server authentication
                        new Oid("1.3.6.1.5.5.7.3.1"),
                    },
                    false));
            DateTimeOffset now = DateTimeOffset.UtcNow;
            return request.CreateSelfSigned(now, now.AddDays(90));
        }
    }

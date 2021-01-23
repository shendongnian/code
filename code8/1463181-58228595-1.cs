    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddCertificateForwarding(options => {
            options.CertificateHeader = "X-ARR-ClientCert";
            options.HeaderConverter = (headerValue) => {
                X509Certificate2 clientCertificate = null;
                try
                {
                    if (!string.IsNullOrWhiteSpace(headerValue))
                    {
                        var bytes = ConvertHexToBytes(headerValue);
                        clientCertificate = new X509Certificate2(bytes);
                    }
                }
                catch (Exception)
                {
                    // invalid certificate
                }
    
                return clientCertificate;
            };
        });
    }

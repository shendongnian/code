    public class X509HttpFactory : DefaultHttpClientFactory
    {
        private readonly X509Certificate2 _cert;
        public ClientWithCertFactory(X509Certificate2 cert) {
            _cert = cert;
        }
        public override HttpMessageHandler CreateMessageHandler() {
            var handler = new WebRequestHandler();
            handler.ClientCertificates.Add(_cert);
            return handler;
        }
    }

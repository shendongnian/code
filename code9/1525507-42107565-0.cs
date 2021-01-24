    namespace ModernHttpClient
    {
        public class NativeMessageHandler : HttpClientHandler
        {
            public NativeMessageHandler();
            public NativeMessageHandler(bool throwOnCaptiveNetwork, bool customSSLVerification, NativeCookieHandler cookieHandler = null);
    
            public bool DisableCaching { get; set; }
    
            public void RegisterForProgress(HttpRequestMessage request, ProgressDelegate callback);
            [AsyncStateMachine(typeof(<SendAsync>c__async0))]
            [DebuggerStepThrough]
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
        }
    }

        private static ChannelFactory<T> CreateSecureChannel<T>(string url, string username, string password)
        {
            var binding = new BasicHttpsBinding
            {
                MessageEncoding = WSMessageEncoding.Text,
                UseDefaultWebProxy = true,
                BypassProxyOnLocal = false,
                Security =
                {
                    Mode = BasicHttpsSecurityMode.TransportWithMessageCredential,
                    Transport =
                    {
                        ClientCredentialType = HttpClientCredentialType.None,
                        ProxyCredentialType = HttpProxyCredentialType.None
                    },
                    Message =
                    {
                        ClientCredentialType = BasicHttpMessageCredentialType.UserName,
                        AlgorithmSuite = SecurityAlgorithmSuite.Default
                    }
                }
            };
            var channel = new ChannelFactory<T>(binding, new EndpointAddress(url));
            var elements = binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;
            var customBinding = new CustomBinding(binding);
            customBinding.Elements.Clear();
            customBinding.Elements.AddRange(elements.ToArray());
            channel.Endpoint.Binding = customBinding;
           
            channel.Credentials.UserName.UserName = username;  
            channel.Credentials.UserName.Password = password;
            return channel;
        }

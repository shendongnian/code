    BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                basicHttpBinding.Security.Mode = BasicHttpSecurityMode.Transport;
                basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                basicHttpBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                basicHttpBinding.Security.Transport.Realm = "weblogic";
                basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
                CustomerPortTypeClient client = new CustomerPortTypeClient(basicHttpBinding,
                    new EndpointAddress("https:....."));
                client.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2(ConfigurationManager.AppSettings["servercertfilepath"].ToString());
                client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["username"].ToString();
                client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["userpwd"].ToString();

    BasicHttpBinding basicHttpbinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            basicHttpbinding.Name = "DockersWSPortBinding";
            basicHttpbinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            basicHttpbinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            EndpointAddress endpointAddress = new EndpointAddress("http://nxl35726:8080/DockersWS/DockersWS?wsdl");
            proxyClient = new DockersWS.DockersWSClient(basicHttpbinding, endpointAddress);
        }

    let authenticate uri username password domain =
      let m = ServiceConfigurationFactory.CreateManagement<IOrganizationService(uri)
      let cred = AuthenticationCredentials()
      cred.ClientCredentials.Windows.ClientCredential <- 
        new NetworkCredential(username, password, domain)
      let ac = m.Authenticate(cred)
      let proxy = new OrganizationServiceProxy(m, ac.ClientCredentials)
      proxy.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());
      proxy

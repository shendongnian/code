     using CredentialManagement;
     return new Credential
     {
         Target = target,
         Type = CredentialType.DomainPassword,
         PersistanceType = PersistanceType.Enterprise,
         Username = string.Format("{0}\\{1}", NetworkManager.DOMAIN, username),
         Password = password,
     }.Save();

            string username = @"domain\username";
            string password = "pass";
            SecureString securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            securePassword.MakeReadOnly();
            PSCredential credentials = new PSCredential(username, securePassword);
            //ExchangeUri=ExUri
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(ExUri), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", credentials);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();

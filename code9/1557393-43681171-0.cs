    const string connectionUri = "https://outlook.office365.com/powershell-liveid/?proxymethod=rps";
    const string schemaUri = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
    const string loginPassword = "password";
    SecureString secpassword = new SecureString();
    foreach (char c in loginPassword)
    {
        secpassword.AppendChar(c);
    }
    PSCredential exchangeCredential = new PSCredential("demo@sample.com", secpassword);
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(connectionUri), schemaUri, exchangeCredential)
    {
        MaximumConnectionRedirectionCount = 5,
        AuthenticationMechanism = AuthenticationMechanism.Basic
    };
    using (var remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo))
    {
        remoteRunspace.Open();
        using (PowerShell powershell = PowerShell.Create())
        {
            powershell.Runspace = remoteRunspace;
            var command = new PSCommand()
                .AddCommand("Set-UserPhoto")
                .AddParameter("Identity", "user@sample.com")
                .AddParameter("PictureData", File.ReadAllBytes(@"C:\Test\MyProfilePictures\pic.jpg"))
                .AddParameter("Confirm", false);
            powershell.Commands = command;
            powershell.Invoke();
        }
    }

    var keybInterMethod = new KeyboardInteractiveAuthenticationMethod(username);
    keybInterMethod.AuthenticationPrompt +=
        (sender, e) => { e.Prompts.First().Response = password; };
    AuthenticationMethod[] methods = new AuthenticationMethod[] {
        new PrivateKeyAuthenticationMethod(username, new PrivateKeyFile(privateKey)),
        keybInterMethod
    };
    ConnectionInfo connectionInfo = new ConnectionInfo(hostname, username, methods);
    using (var sftp = new SftpClient(connectionInfo))
    {
        sftp.Connect();
        // ...
    }

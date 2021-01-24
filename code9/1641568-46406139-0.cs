    public string ExecuteCommandSsh(string host, int port, string username, string password, string[] commands)
    {
        var returnMessage = string.Empty;
        try
        {
            using (var client = new SshClient(host, port, username, password))
            {
                //Create the command string
                var fullCommand = string.Empty;
                foreach (var command in commands)
                {
                    fullCommand += command + "\n";
                }
                client.Connect();
                var sshCommand = client.CreateCommand(fullCommand);
                sshCommand.CommandTimeout = new TimeSpan(0, 0, 10);
                try
                {
                    sshCommand.Execute();
                    returnMessage = sshCommand.Result;
                }
                catch (SshOperationTimeoutException)
                {
                    returnMessage = sshCommand.Result;
                }
                client.Disconnect();
            }
        }
        catch (Exception e)
        {
            //other exception
        }
        return returnMessage;
    }

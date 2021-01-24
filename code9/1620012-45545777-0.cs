    using (var client = new SshClient(host, user, pass))
    {
    client.Connect();
    string message = Console.ReadLine();
    var mycommand = client.RunCommand("echo " + message + " >> file.txt");
    client.Disconnect();
    }

    var promptRegex = new Regex(@"\][#$>]"); // regular expression for matching terminal prompt
    var modes = new Dictionary<Renci.SshNet.Common.TerminalModes, uint>();
    using (var stream = ssh.CreateShellStream("xterm", 255, 50, 800, 600, 1024, modes))
    {
        stream.Write("sudo iptables -L -n\n");
        stream.Expect("password");
        stream.Write("mypassword\n");
        var output = stream.Expect(promptRegex);
    }

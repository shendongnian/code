    public async void Start(IProgress<int> progress)
    {
        torProcess = new Process();
        torProcess.StartInfo.FileName = @"D:\...\tor.exe";
        torProcess.StartInfo.Arguments = @"-f ""D:\...\torrc""";
        torProcess.StartInfo.UseShellExecute = false;
        torProcess.StartInfo.RedirectStandardOutput = true;
        torProcess.StartInfo.CreateNoWindow = true;
        torProcess.Start();
        var reader = torProcess.StandardOutput;
        while (true)
        {
            var line = await reader.ReadLineAsync();
            if (line == null)
            {
                // EOF
                Environment.Exit(0);
            }
            // Get loading status
            foreach (Match m in Regex.Matches(line, @"Bootstrapped (\d+)%"))
            {
                progress.Report(Convert.ToInt32(m.Groups[1].Value));
            }
    
            if (line.Contains("100%: Done"))
            {
                // Tor loaded
                break;
            }
            if (line.Contains("Is Tor already running?"))
            {
                // Tor already running
                break;
            }
        }
    
        proxy = new SocksWebProxy(new ProxyConfig(
            //This is an internal http->socks proxy that runs in process
            IPAddress.Parse("127.0.0.1"),
            //This is the port your in process http->socks proxy will run on
            12345,
            //This could be an address to a local socks proxy (ex: Tor / Tor Browser, If Tor is running it will be on 127.0.0.1)
            IPAddress.Parse("127.0.0.1"),
            //This is the port that the socks proxy lives on (ex: Tor / Tor Browser, Tor is 9150)
            9150,
            //This Can be Socks4 or Socks5
            ProxyConfig.SocksVersion.Five
        ));
        progress.Report(100);
    }

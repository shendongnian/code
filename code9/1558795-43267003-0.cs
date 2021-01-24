    // use the IP Address of your DNS server
    var endpoint = new IPEndPoint(IPAddress.Parse("1.2.3.4"), 53);
    var client = new LookupClient(endpoint);
    // then query for the host in your domain and ask for an A or AAAA record
    var result = client.Query("YouHost.yourdomain", QueryType.A);
    var ipRecord = result.Answers.ARecords().First();
    Console.WriteLine($"IP: {ipRecord.Address}.");
    // shortcut
    var entry = client.GetHostEntry("YourHost.yourdomain");
    Console.WriteLine($"IP: {entry.AddressList.First()} hostName: {entry.HostName}");

    using (var client = new TcpClient("127.0.0.1", 8100))//"127.0.0.1", 5055
    while (true)
    {
        using (var sw = new StreamWriter(client.GetStream()))
        using (var s = client.GetStream())
        {
            b1 = File.ReadAllBytes(op.FileName);
            //  s = client.GetStream();
            s.Write(b1, 0, b1.Length);
            sw.WriteLine(n);
            sw.Flush();
        }
        Thread.Sleep(18000);
    }

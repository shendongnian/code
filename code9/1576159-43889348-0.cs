        using (var client = new TcpClient())
        {
            client.Connect("host", 2324);
            using (var ns = client.GetStream())
            using (var writer = new StreamWriter(ns))
            {
                writer.Write(xml);
                writer.Write("\r\n\r\n");
                writer.Flush();
            }
            client.Close();
        }

    string file = @"C:\test.zip";
    string url = @"http://foo.bar";
    using (System.IO.Stream fileStream = System.IO.File.OpenRead(file))
    {
        using (ExtendedWebClient client = new ExtendedWebClient(fileStream.Length))
        {
            using (System.IO.Stream requestStream = client.OpenWrite(new Uri(url), "POST"))
            {
                byte[] buffer = new byte[16 * 1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }

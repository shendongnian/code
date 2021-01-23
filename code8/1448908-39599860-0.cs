    string host = @"https://localhost/";
    string certName = @"C:\temp\cert.pfx";
    string password = @"password";
    try
    {
        X509Certificate2Collection certificates = new X509Certificate2Collection();
        certificates.Import(certName, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
        ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(host);
        req.AllowAutoRedirect = true;
        req.ClientCertificates = certificates;
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        string postData = "login-form-type=cert";
        byte[] postBytes = Encoding.UTF8.GetBytes(postData);
        req.ContentLength = postBytes.Length;
        Stream postStream = req.GetRequestStream();
        postStream.Write(postBytes, 0, postBytes.Length);
        postStream.Flush();
        postStream.Close();
        WebResponse resp = req.GetResponse();
        Stream stream = resp.GetResponseStream();
        using (StreamReader reader = new StreamReader(stream))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
        }
    
        stream.Close();
    }
    catch(Exception e)
    {
        Console.WriteLine(e);
    }

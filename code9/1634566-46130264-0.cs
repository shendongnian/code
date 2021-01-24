    using (WebClient client = new WebClient())
    {
        client.Credentials = new NetworkCredential(Login, Password);
        client.UploadFile(DestPath, "STOR", SouPath);
    }

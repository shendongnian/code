    public static void UploadFile(string targeUrl, ICredentials credentials, string fileName)
    {
        using (var client = new WebClient())
        {
            client.Credentials = credentials;
            client.UploadFile(targeUrl, "PUT", fileName);
        }
    }

    public static void Download(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            webClient.DownloadFile(url, @"C:\Users\Sean\Desktop\StockApp\StockApp\StockApp\report.txt");
        }

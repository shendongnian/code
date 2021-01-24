    string pdfUrl = "URL_TO_PDF";
    using(WebClient client = new WebClient())
    {
         var bytes = client.DownloadData(pdfUrl);
         string base64String = Convert.ToBase64String(bytes);
    }

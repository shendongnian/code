            You can use below code to download pdf from url into base 64 string format.
            string pdfUrl = "url to pdf";
            WebClient client = new WebClient();
            var bytes = client.DownloadData(pdfUrl);
            String base64String = Convert.ToBase64String(bytes);

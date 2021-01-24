               string url = String.Format("http://www.example.com);
    
                WebClient webClient = new WebClient();
    
                webClient.Encoding = System.Text.Encoding.GetEncoding(1256);
    
    
                string result = webClient.DownloadString(url);

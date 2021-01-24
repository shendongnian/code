        string GetPublicIP()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("http://checkip.dyndns.org/");
            string webData = System.Text.Encoding.UTF8.GetString(raw);
            string[] body = webData.Split(new[] { "<body>", "</body>" }, StringSplitOptions.RemoveEmptyEntries);
            string[] ip = body[1].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            return ip[1];
         }

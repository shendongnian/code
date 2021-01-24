    var imageUrl = "progress.jpg";
        
    using (var wc = new WebClient())
    {
       byte[] imageBytes = wc.DownloadData(imageUrl);
                    
       string hex = BitConverter.ToString(imageBytes.Take(500).ToArray());
       var imageAsHex = hex.Replace("-", "").ToUpper();
        
       Console.WriteLine("Is JPEG: " + imageAsHex.Contains("FFD8"));
       Console.WriteLine("Is Progressive: " + imageAsHex.Contains("FFC2"));
    }

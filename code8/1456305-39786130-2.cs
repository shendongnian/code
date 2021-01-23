    public static string DoIt()
    {
            string htmlString = "";
            using (WebClient client = new WebClient())
                htmlString = client.DownloadString("http://dean.edwards.name/my/base64-ie.html"); //This is an example source for base64 img src, you can change this directly to your source.
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlString);
            document.DocumentNode.Descendants("img")
                                .Where(e =>
                                {
                                    string src = e.GetAttributeValue("src", null) ?? "";
                                    return !string.IsNullOrEmpty(src) && src.StartsWith("data:image");
                                })
                                .ToList()
                                .ForEach(x =>
                                {
                                    string currentSrcValue = x.GetAttributeValue("src", null);
                                    currentSrcValue = currentSrcValue.Split(',')[1];//Base64 part of string
                                    byte[] imageData = Convert.FromBase64String(currentSrcValue);
                                    string contentId = Guid.NewGuid().ToString();
                                    LinkedResource inline = new LinkedResource(new MemoryStream(imageData), "image/jpeg");
                                    inline.ContentId = contentId;
                                    inline.TransferEncoding = TransferEncoding.Base64;
                                    x.SetAttributeValue("src", "cid:" + inline.ContentId);
                                });
            string result = document.DocumentNode.OuterHtml;
    }

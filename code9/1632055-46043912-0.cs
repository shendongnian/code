    mailMessage.Body = GetFormattedEntries(279);
    var picList = new List<LinkedResource>();
    
    
    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
    htmlDocument.LoadHtml(mailMessage.Body);
    var images = htmlDocument.DocumentNode.Descendants("img").ToList();
    
    foreach (var image in images)
    {
    
    	var src = image.Attributes["src"].Value;
    	var regex = new Regex(@"data:(?<mime>[\w/\-\.]+);(?<encoding>\w+),(?<data>.*)", RegexOptions.Compiled);
    	var match = regex.Match(src);
    	var mime = match.Groups["mime"].Value;
    	var encoding = match.Groups["encoding"].Value;
    	var data = match.Groups["data"].Value;
    
    	byte[] bytes = Convert.FromBase64String(data);
    	System.IO.MemoryStream embeddedMs = new System.IO.MemoryStream(bytes, 0, bytes.Length);
    	LinkedResource pic1 = new LinkedResource(embeddedMs, new System.Net.Mime.ContentType(mime));
    	pic1.TransferEncoding = TransferEncoding.Base64;
    	pic1.ContentId = Guid.NewGuid().ToString();
    	picList.Add(pic1);
    	var newNode = image.CloneNode(true);
    	newNode.Attributes.Remove(newNode.Attributes["class"]);
    	newNode.Attributes["src"].Value = string.Format("cid:{0}", pic1.ContentId);
    	image.ParentNode.ReplaceChild(newNode, image);
    }
    
    
    mailMessage.IsBodyHtml = true;
    mailMessage.Body = htmlDocument.DocumentNode.OuterHtml;
    
    AlternateView avHtml = AlternateView.CreateAlternateViewFromString(mailMessage.Body, null, MediaTypeNames.Text.Html);
    
    foreach (var pic in picList)
    	avHtml.LinkedResources.Add(pic);
    
    
    mailMessage.AlternateViews.Add(avHtml);
    
    mailMessage.SendMail();

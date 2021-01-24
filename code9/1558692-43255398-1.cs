         string urlAddress = "url.com";
    
         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
         HttpWebResponse response = (HttpWebResponse)request.GetResponse();
         string data = "";
         if (response.StatusCode == HttpStatusCode.OK)
         {
         Stream receiveStream = response.GetResponseStream();
         StreamReader readStream = null;
    
         if (response.CharacterSet == null)
         {
             readStream = new StreamReader(receiveStream);
         }
         else
         {
             readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
         }
    
         data = readStream.ReadToEnd();
    
    
         response.Close();
         readStream.Close();
        }
    
         HtmlDocument document2 = new HtmlAgilityPack.HtmlDocument();
         document2.LoadHtml(data);

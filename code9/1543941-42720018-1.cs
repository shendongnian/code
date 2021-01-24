    WebRequest request = WebRequest.Create("...");
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Stream dataStream = response.GetResponseStream();
    StreamReader reader = new StreamReader(dataStream);
    string responseFromServer = reader.ReadToEnd();
    byte[] bytes = new byte[responseFromServer.Length];// = Convert.FromBase64String(responseFromServer);
    using (var reader = XmlReader.Create(new StringReader(responseFromServer))
    {
        reader.Read();
        int len = reader.ReadElementContentAsBase64(bytes, 0, responseFromServer.Length);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes, 0, len))
        {
            image = Image.FromStream(ms);
            image.Save("File", System.Drawing.Imaging.ImageFormat.Gif);
        }
    }

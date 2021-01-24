    WebRequest request = WebRequest.Create("...");
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Stream dataStream = response.GetResponseStream();
    //StreamReader reader = new StreamReader(dataStream);
    //string responseFromServer = reader.ReadToEnd();
    byte[] bytes;// = Convert.FromBase64String(responseFromServer);
    using (var reader = XmlReader.Create(dataStream))
    {
        reader.ReadElementContentAsBase64(bytes, 0, dataStream.Length);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
            image.Save("File", System.Drawing.Imaging.ImageFormat.Gif);
        }
    }

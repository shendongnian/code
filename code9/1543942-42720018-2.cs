    WebRequest request = WebRequest.Create("...");
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Stream dataStream = response.GetResponseStream();
    //StreamReader reader = new StreamReader(dataStream);
    //string responseFromServer = reader.ReadToEnd();
    //byte[] bytes = Convert.FromBase64String(responseFromServer);
    using (var reader = XmlReader.Create(dataStream))
    {
        reader.Read();
        reader.Read();
        string base64 = reader.Value;
        byte[] bytes = Convert.FromBase64String(base64);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
            image.Save("File", System.Drawing.Imaging.ImageFormat.Gif);
        }
    }

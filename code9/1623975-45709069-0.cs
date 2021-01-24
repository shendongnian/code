    using (HttpWebResponse  response = (HttpWebResponse)request.GetResponse())
    {
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new ApplicationException("error code " + response.StatusCode.ToString());
        }
        Encoding enc = System.Text.Encoding.GetEncoding(1252);
        using(StreamReader loResponseStream = new StreamReader(response.GetResponseStream(), enc))
        {
            return loResponseStream.ReadToEnd();
        }
    }

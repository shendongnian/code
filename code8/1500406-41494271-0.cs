    ...
    using (HttpWebResponse webResponse = (HttpWebResponse)req.GetResponse())
    {
        String tempFile = Path.GetTempFileName();
        using (var stream = webResponse.GetResponseStream())
        {
            if (stream != null)
            {
                using (FileStream file = File.Create(tempFile))
                {
                    stream.CopyTo(file);
                }
            }
        }
        Log(url, "stream reader (responseStream.ReadToEnd) completed to string.");
    }

    using (var client = new WebClient())
    {
        try
        {
            client.DownloadFile(url, path);
        }
        catch (WebException e)
        {
            var statusCode = ((HttpWebResponse) e.Response).StatusCode;
            if (statusCode == HttpStatusCode.NotFound && System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                //maybe log the occurence as well
            }
        }
    }

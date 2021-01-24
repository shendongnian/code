    try
    {
        client.DownloadString("https://www.americasarmy.com/soldier/1309069");
    }
    catch (WebException webex)
    {
        using (var streamReader = new StreamReader(webex.Response.GetResponseStream()))
        {
            var htmlCode = streamReader.ReadToEnd(); 
        }
    }

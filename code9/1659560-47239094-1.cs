    HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    try
    {
        var request = (HttpWebRequest)WebRequest.Create("https://www.dofus.com/en/mmorpg/encyclopedia/weapons/180-limbo-wand");
        request.Method = "GET";
        
        using (var response = (HttpWebResponse)request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                doc.Load(stream, Encoding.GetEncoding("iso-8859-9"));
            }
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine(ex.Message);
    }

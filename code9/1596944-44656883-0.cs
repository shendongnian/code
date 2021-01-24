    {
        string apiurl = "http://api.chartlyrics.com/apiv1.asmx/SearchLyricText?lyricText=";
        string lyric = System.Net.WebUtility.UrlEncode(input);
        var myList = new List<string>();
    
        XmlDocument xmlDoc = new XmlDocument();
        XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
        ns.AddNamespace("ns", "http://api.chartlyrics.com/");
        xmlDoc.Load(apiurl + lyric);
    
        //I'd change this part only
        XmlNodeList searchResult = xmlDoc.SelectNodes("/ns:ArrayOfSearchLyricResult/ns:SearchLyricResult", ns)
        foreach (XmlNode item in searchResult)
        {
            if (item != null)
            {
            myList.Add(item["Artist"].InnerText + " - " + example["Song"].InnerText;);
            }
        }
    
        var results = myList.ToArray();
        return results;
    }

    if (videoLink.Host == "estream.to")
    {
       IEnumerable<HtmlNode> links = doc.DocumentNode.Descendants("script").Where(l => l.Attributes.Contains("type") && (l.InnerText.Contains("mp4") || l.InnerText.Contains("m3u8")) && l.InnerText.Contains("(p,a,c,k,e,d)"));
        foreach (var link in links)
        {
           value = link.InnerText;
           if (value.Contains("mp4"))
           {
              value = link.InnerText;
              break;
           }
        }
        string[] data = Regex.Match(value, "'([a-zA-Z0-9_|]{30,})'").Groups[1].Value.Split('|');
        if (data.Count() > 20)
        {
           value = string.Format("https://{0}.{1}.{2}/{3}/{4}.m3u8", data[10], data[4], data[3], data[136], data[17]);
        }
        
        }
        else if (videoLink.Host == "streamin.to")
        {
             IEnumerable<HtmlNode> links = doc.DocumentNode.Descendants("script").Where(l => l.Attributes.Contains("type") && (l.InnerText.Contains("mp4") || l.InnerText.Contains("m3u8")) && l.InnerText.Contains("(p,a,c,k,e,d)"));
        foreach (var link in links)
        {
           value = link.InnerText;
           if (value.Contains("mp4"))
           {
               value = link.InnerText;
               break;
           }
        }
        string[] data = Regex.Match(value, "'([a-zA-Z0-9_|]{30,})'").Groups[1].Value.Split('|');
        if (data.Count() > 20)
        {
            List<int> ip = new List<int>();
            for (int x = 41; x <= 50; x++)
            {
               //check ip
               int val = 0;
               int.TryParse(data[x], out val);
               if (val != 0)
               {
                  ip.Add(val);
               }
            }
            if (ip.Count > 0)
            {
               int[] ipValue = ip.ToArray();
               string secondParam = "";
               for (int x = 0; x < data.Count(); x++)
               {
                   // string length is more than 50
                   if (data[x].Length > 50)
                   {
                      secondParam = data[x];
                   }
               }
      // Edit: I have come across a problem with this so I am updating the answer.
               if (ipValue.Count() == 4)
               {
                  value = string.Format("http://5.{0}.{1}.{2}:{3}/{4}/v.mp4", ipValue[3], ipValue[2], ipValue[1], ipValue[0], secondParam);
               }
               else if (ipValue.Count() == 5)
               {
                  value = string.Format("http://{0}.{1}.{2}.{3}:{4}/{5}/v.mp4", ipValue[4], ipValue[3], ipValue[2], ipValue[1], ipValue[0], secondParam);
               }
               else
               {
                  // this is where the problem occurs 
               }
            }
        }

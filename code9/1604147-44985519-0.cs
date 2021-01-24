    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.ntv.com.tr/gundem.rss");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string responseString = stream.ReadToEnd();
            string xmlString = responseString.Replace("xmlns=\"http://www.w3.org/2005/Atom\"", "");
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlString);
            var feedNode = xdoc.LastChild;
            XmlNodeList entries = feedNode.SelectNodes("entry");
            List<NTV> NTVNewsList = new List<NTV>();
 
            foreach (XmlNode entry in entries)
            {
                NTV NTVInstance = new NTV();
                foreach (XmlNode child in entry.ChildNodes)
                {
                    string childName = child.Name;
                    switch (childName)
                    {
                        case "title":
                            NTVInstance.Title = child.InnerText;
                            break;
                        case "summary":
                            NTVInstance.Description = child.InnerText;
                            break;
                        case "published":
                            string dateStr = child.InnerText;
                            NTVInstance.PubDate = Convert.ToDateTime(dateStr);
                            break;
                        case "link":
                            NTVInstance.Link = child.Attributes["href"].Value;
                            NTVInstance.Tags = GetTags(NTVInstance.Link);
                            break;
                        default:
                            break;
                    }
                }

    public class WebScrapper
    {
        public IEnumerable<string> GetLinkToAllCountries(Uri uri)
        {
            return from node in XElement.Load(uri.AbsoluteUri).Elements("body").Descendants()
                where node.Name.LocalName == "a"
                      && node.Parent.Name.LocalName == "td"
                      && node.Parent.Parent.Name.LocalName == "tr"
                      && node.Attribute("href") != null
                      && node.Attribute("title") != null
                select uri.Scheme + "://" + uri.Host + node.Attribute("href").Value;
        }
        public IEnumerable<string> ListOfCapitals(string link)
        {
            return from node in XElement.Load(link).Elements("body").Descendants()
                where node.Name.LocalName == "a"
                      && node.Parent.Name == "td"
                      && node.Attribute("title") != null
                select node.Attribute("title").Value;
        }
    }

     public class Url
    {
        public string Loc { get; set; }
        public string Changefreq { get; set; }
        public string Lastmod { get; set; }
        public Image Image { get; set; }
    }
    public class Image
    {
        public string Loc { get; set; }
        public string Title { get; set; }
    }
    public class Repository
    {
        private XElement xmlDatas;
        public Repository(string filePath)
        {
            xmlDatas = XElement.Load(filePath);
        }
        public List<Url> FindAll()
        {
            return xmlDatas.Elements("url")
                .Select(url =>
                {
                    Url data = new Url();
                    if(url.Element("loc") != null)
                    {
                        data.Loc = url.Element("loc").Value;
                    }
                    if(url.Element("changefreq") != null)
                    {
                        data.Changefreq = url.Element("changefreq").Value;
                    }
                    if(url.Element("lastmod") != null)
                    {
                        data.Lastmod = url.Element("lastmod").Value;
                    }
                    if (url.Element("image:image") != null)
                    {
                        Image image = new Image();
                        //All images must have loc and title tags.
                        image.Loc = url.Element("image:image").Element("image:loc").Value;
                        image.Title= url.Element("image:image").Element("image:title").Value;
                    }
                    return data;
                }).ToList();
        }
    }

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
        private XDocument xmlDatas;
        public Repository(string filePath)
        {
            xmlDatas = XDocument.Load(filePath);
        }
        public List<Url> FindAll()
        {
            return xmlDatas.Elements().Elements()
                .Select(url =>
                {
                    Url data = new Url();
                    foreach (var item in url.Elements())
                    {
                        switch (item.Name.LocalName)
                        {
                            case "loc":
                                data.Loc = item.Value;
                                break;
                            case "changefreq":
                                data.Changefreq = item.Value;
                                break;
                            case "lastmod":
                                data.Lastmod = item.Value;
                                break;
                            case "image":
                                Image image = new Image();
                                foreach (var img in item.Elements())
                                {
                                    switch (img.Name.LocalName)
                                    {
                                        case "loc":
                                            image.Loc = img.Value;
                                            break;
                                        case "title":
                                            image.Title = image.Title;
                                            break;
                                    }
                                }
                                data.Image = image;
                                break;
                        }
                        var s = item.Name.LocalName;
                    }
                    return data;
                }).ToList();
        }
    }

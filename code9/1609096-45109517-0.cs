    public static void CreateGenresXml(string[] args)
    {
            var el = new XElement("Genres");
            el.Add(args.Where(x => !string.IsNullOrWhiteSpace(x)).Select(arg => new XElement("Genre", new XAttribute("Value", arg))));
            
    }

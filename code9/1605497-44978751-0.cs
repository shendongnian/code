    public IReadOnlyCollection<string> SearchByCost(XDocument xdoc, double cost) 
    {
        return xdoc.Root.Elements("Movie")
            .Where(movie => (double)movie.Element("Cost") < cost)
            .Select(movie => movie.Element("Name").Value)
            .ToList();
    }

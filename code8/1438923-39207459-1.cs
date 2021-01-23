    Func<string,int> ParseIntOrDefault = (string input) =>
    {
        int output;
        int.TryParse(input, out output);
        return output;
    };
    var result = XDocument.Load("data.xml")
                          .Descendants("ImageInfo")
                          .OrderBy(element => ParseIntOrDefault(element.Element("pos")?.Value))
                          .ToList();

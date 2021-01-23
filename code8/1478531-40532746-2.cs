    string[] valuesToPrint = { "lon", "lat", "ele", "time", "course", "pitch", "roll" };
    XNamespace ns = "http://www.topografix.com/GPX/1/1";
    File.WriteAllLines("Flight1.csv",
        new[] { string.Join(",", valuesToPrint) }
        .Concat(XDocument.Load("Flight1.xml")
        .Descendants(ns + "trkpt")
        .Select(e =>
        {
            return string.Join(",", e.Attributes()
                .Where(a => valuesToPrint.Contains(a.Name.LocalName))
                .Select(a => a.Value)
                .Concat(e.Elements()
                    .Where(c => valuesToPrint.Contains(c.Name.LocalName))
                    .Select(c => c.Value)).ToArray());
        })));

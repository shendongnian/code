    XDocument GetXml(string path)
    {
        using (var file = File.OpenText(path))
        {
            var name = file.ReadLine();
            return new XDocument(
                new XElement("Project",
                    new XAttribute("Name", name),
                    from row in ReadRows(file)
                    group row.Item2 by row.Item1 into g
                    select new XElement(g.Key,
                        from r in g
                        select new XElement(r)
                    )
                )
            );
        }
    }
    
    IEnumerable<Tuple<string, string>> ReadRows(TextReader file)
    {
        using (var reader = new CsvReader(file, new CsvConfiguration { HasHeaderRecord = false, TrimFields = true }))
        {
            while (reader.Read())
                yield return Tuple.Create(reader.GetField(0), reader.GetField(1));
        }
    }

    var x = XDocument.Parse("<x xml:space='preserve'>&#xd;\r\n</x>");
    present("content", x.Root.Value); // 13 10, expected
    present("formatted", toString(x)); // inside <x/>: 38 35 120 68 59 10 ("&#xD;\n"), acceptable
    x = XDocument.Parse(toString(x));
    present("round tripped", x.Root.Value); // 13 10, expected
    
    string toString(XDocument xd)
    {
        using var sw = new StringWriter();
        using (var writer = XmlWriter.Create(sw, new XmlWriterSettings
        {
            NewLineHandling = NewLineHandling.Entitize,
        }))
        {
            xd.WriteTo(writer);
        }
        return sw.ToString();
    }
    void present(string label, string thing)
    {
        Console.WriteLine(label);
        Console.WriteLine(thing);
        Console.WriteLine(string.Join(" ", Encoding.UTF8.GetBytes(thing)));
        Console.WriteLine();
    }

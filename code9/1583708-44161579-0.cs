    MemoryStream stream = new MemoryStream();
    using (var writer = new StreamWriter(stream, Encoding.UTF8);
        foreach (var line in File.ReadLines(fileName).SkipWhile(s => s.StartsWith("#"))) {
            writer.WriteLine(line);
        }
    }
    stream.Position = 0;
    Table t = Table.Load(stream);

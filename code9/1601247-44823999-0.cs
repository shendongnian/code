    using (var fs = File.OpenRead(csvUrl))
    using (var reader = new StreamReader(fs, Encoding.UTF8))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (i > 0)
            {
                TextFieldParser parser = new TextFieldParser(new StringReader(lineContent));
                parser.SetDelimiters(",");
                string[] rawFields = parser.ReadFields();
            }
        }
    }

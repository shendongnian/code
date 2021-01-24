    using (var stream = client.OpenRead(seriesUrl))
    {
        using (var reader = new StreamReader(stream))
        {
            string lastLine;
            while ((lastLine = reader.ReadLine()) != null)
            {
                // Do nothing...
            }
            // lastLine now contains the very last line from reader
        }
    }

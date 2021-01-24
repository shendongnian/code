    if (!System.IO.File.Exists(filepath))
    {
        using (var writer = new StreamWriter(filepath, true))
        {
            writer.Write(htmltext);
        }
    }
    else
    {
        var txt = System.IO.File.ReadAllText(filepath);
    }

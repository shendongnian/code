    using(var writer=File.CreateText(targetPath))
    {
        foreach(var line in File.ReadLines(somePath))
        {
            var newline=regex.Replace(line," ");
            writer.WriteLine(newline);
        }
    }

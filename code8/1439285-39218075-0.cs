    var sb = new StringBuilder();
    while (reader.Peek() > -1)
    {
         var line = reader.ReadLine();
         sb.AppendLine(line);
    }
    // Write to file.
    File.WriteAllText(filePath, sb.ToString());

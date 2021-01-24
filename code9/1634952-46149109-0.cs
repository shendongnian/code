    while (line != null)
    {
        if (line.Length > 3)
        {
            line = line.Split('/')[1];
            result.Append(line);
            result.Append("\n");
        }
        line = reader.ReadLine();
    }

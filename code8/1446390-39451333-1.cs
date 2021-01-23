    foreach (var file in dir.GetFiles()) //here is the exception
    {
        try
        {
            info.Add(new XElement("file", new XAttribute("name", file.Name)));
        }
        catch (UnauthorizedAccessException)
        {
            // Don't have access, so skip the file
            // You could output an error here, if you like.
        }
    }

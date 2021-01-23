    string result = reader.ReadToEnd();
    string[] lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    if (lines.Length >= 9)
    {
        Console.WriteLine(lines[8]);
    }
    else
    {
        // handle error
    }

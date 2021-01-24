    using (StreamReader inputStream = new StreamReader(filepath, System.Text.Encoding.UTF8))
    {
        string line = inputStream.ReadToEnd();
        Console.WriteLine(line);
    }

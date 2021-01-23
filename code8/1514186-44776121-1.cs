    using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(System.IO.File.Create(filePath).Dispose()))
    {
        file.WriteLine("your text here");
    }

    string line;
    var stringBuilder = new StringBuilder();
    using (var memoryMappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateFromFile(@"D:\Temp\test.txt"))
    using (var viewStream = memoryMappedFile.CreateViewStream())
    using (var streamReader = new StreamReader(viewStream))
    {
        while ((line = streamReader.ReadLine()) != null)
            if (line.EndsWith(myWord))
                stringBuilder.AppendLine(line);
    }
    outputEmails.Text = stringBuilder.ToString();

    var filename = "client.txt";
    var info = new FileInfo(filename);
    var text = new StringBuilder();
    using (var stream = new FileStream(filename, FileMode.Open))
    using (var reader = new StreamReader(stream))
    {
        while (!reader.EndOfStream)
        {
            text.AppendLine(reader.ReadLine());
            var progress = Convert.ToDouble(stream.Position) * 100 / info.Length;
            Console.WriteLine(progress);
        }
    }
    var result = text.ToString();

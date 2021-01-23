    var lines = new List<string>();
    using(var fileStream = new FileStream(@"c:\location\test.txt", FileMode.Open, FileAccess.Read)
    using(var streamReader = new StreamReader(fileStream, Encoding.UTF8) {
        while (!streamReader.EndOfStream) {
            lines.Add(streamReader.ReadLine());
        }
    }
    lines[0].Replace("test", "Test");

    static async Task MainAsync()
    {
      var tasks = Enumerable.Range(0, 5).Select(TestFilesAsync).ToList();
      await Task.WhenAll(tasks);
    }
    static async Task TestFilesAsync(int i)
    {
      using (var filestream = File.Open(@"c:\pdftest\" + i.ToString() +@".docx", FileMode.Open))
        await test(filestream, i.ToString());
    }

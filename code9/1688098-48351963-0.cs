    private async Task WriteToFile()
    {
      using (var fileStream = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Write))
      using (var writer = new StreamWriter(fileStream))
      {
        await Task.Delay(500); // some other work
        await writer.WriteLineAsync("Lorem ipsum");
      }
    }

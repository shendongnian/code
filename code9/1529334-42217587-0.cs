    static void Main(string[] args)
    {
      Console.WriteLine("Job Start:");
      MainAsync().GetAwaiter().GetResult();
      Console.WriteLine("End.");
      Console.ReadLine();
    }
    static async Task MainAsync()
    {
      for (int i = 0; i < 5; i++)
      {
        using (var filestream = File.Open(@"c:\pdftest\" + i.ToString() +@".docx", FileMode.Open))
          await test(filestream, i.ToString());
      }
    }

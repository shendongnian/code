    const string filename = "wwwroot/Counter/RLSBC.txt";
    using (var counterStream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
    {
         int visits;
         using (var reader = new StreamReader(counterStream, System.Text.Encoding.UTF8, true, 4096, true))
         {
              string line = reader.ReadLine();
              int.TryParse(line, out visits);
         }
         visits = visits + 1;
         counterStream.Seek(0L, SeekOrigin.Begin);
         using (var writer = new StreamWriter(counterStream))
         {
              writer.Write(visits);
         }
    }

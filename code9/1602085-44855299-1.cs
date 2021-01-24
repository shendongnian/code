    using (var client = new HttpClient())
    {
      using (var stream = await client.GetStreamAsync("http://localhost:9000/api/event"))
      {
        using (var reader = new StreamReader(stream))
        {
          while (true)
          {
            Console.WriteLine(reader.ReadLine());
          }
        }
      }

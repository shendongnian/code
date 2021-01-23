    public void SplitCsvTest()
    {
      var inventoryRecords = new List<InventoryCsvItem>();
      for (int i = 0; i < 100000; i++)
      {
        inventoryRecords.Add(new InventoryCsvItem { ListPrice = i + 1, Quantity = i + 1 });
      }
      const decimal MAX_BYTES = 5 * 1024 * 1024; // 5 MB
      List<byte[]> parts = new List<byte[]>();
      using (var memoryStream = new MemoryStream())
      {
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter))
        {
          csvWriter.WriteHeader<InventoryCsvItem>();
          csvWriter.NextRecord();
          csvWriter.Flush();
          streamWriter.Flush();
          var headerSize = memoryStream.Length;
          foreach (var record in inventoryRecords)
          {
            
            csvWriter.WriteRecord(record);
            csvWriter.NextRecord();
            csvWriter.Flush();
            streamWriter.Flush();
            if (memoryStream.Length > (MAX_BYTES - headerSize))
            {
              parts.Add(memoryStream.ToArray());
              memoryStream.SetLength(0);
              memoryStream.Position = 0;
              csvWriter.WriteHeader<InventoryCsvItem>();
              csvWriter.NextRecord();
            }
          }
          if (memoryStream.Length > headerSize)
          {
            parts.Add(memoryStream.ToArray());
          }
        }
        
      }
      for(int i = 0; i < parts.Count; i++)
      {
        var part = parts[i];
        File.WriteAllBytes($"C:/Temp/Part {i + 1} of {parts.Count}.csv", part);
      }
    }

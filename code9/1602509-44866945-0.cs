    inventoryList.Select((item, index) => new { Index = index, Name = item })
                 .ToList()
                 .ForEach(it =>
                          {
                             Console.WriteLine("{0} - {1}", it.Index + 1, it.Name);
                          });

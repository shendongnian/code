    var grouped = list.Select(item => new 
                      {
                          Parsed = DateTime.ParseExact(item.Day, "yyyy-M-dd", CultureInfo.InvariantCulture), 
                          Number = item.Number
                      })
                      .OrderBy(item => item.Parsed)
                      .Select((item, index) => new 
                      {
                          Index = index, 
                          Item = item
                      })
                      .GroupBy(item => item.Index / 5)
                      .Select(gr => new 
                      {
                          Date = gr.First().Item.Parsed, 
                          Count = gr.Sum(x => x.Item.Number)
                      })
                      .ToList();

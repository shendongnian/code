    IEnumerable<string> ReadFile(string path)  
    {
    using (var stream = File.OpenRead(path))
         using (var reader = new StreamReader(stream))
        {
            while (reader.Peek() >= 0)
           {
                  yield return reader.ReadLine();
           }
        }
    }
    var items =  
        from line in ReadFile(@"C:\products.csv")
        let values = line.Split(',')
        select new Product {Sku = values[0], Name = values[1]};

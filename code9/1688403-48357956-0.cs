    string line1 = File.ReadLines("MyFile.txt").First(); 
    byte[] byteArray = Encoding.UTF8.GetBytes( line1 );
    using (var stream = new MemoryStream( byteArray ))
    {
      ...
    }

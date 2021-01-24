    using(var csvReader = new StreamReader(System.IO.File.OpenRead("your file path")))
    {
         while (!csvReader.EndOfStream)
         {
              var rows = csvReader.ReadLine();
              var columns = rows.Split(';');
              if(values.Length > 1)
              {
                   // Your logic getting values to save db
              }
         }
    }

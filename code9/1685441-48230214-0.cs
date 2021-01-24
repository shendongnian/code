      string csvFilePath = /* CSV file directory */
      string csvFileName = /* CSV file name */
      using (FileStream sr = new FileStream(csvFilePath + "\\schema.ini", 
          FileMode.Create, FileAccess.Write)) 
      { 
          using (StreamWriter writer=new StreamWriter(sr)) 
          { 
              writer.WriteLine("[" + csvFileName + "]"); 
              writer.WriteLine("ColNameHeader=True"); 
              writer.WriteLine("Format=CSVDelimited"); 
              writer.WriteLine("TextDelimiter=none"); 
              writer.Close(); 
              writer.Dispose(); 
          } 
      } 

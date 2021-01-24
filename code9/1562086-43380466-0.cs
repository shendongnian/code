       /// Disposal of your reader when unused is essential to close your file
       using(var reader = new StreamReader(OpenFile.FileName))   
       {
          var lines = reader.ReadToEnd().Split(new char[] { '\n' });
          int NumLines = lines.Length;
          for (int i = 0; i < NumLines; i++)
          {
               ... do something here
          }
       }

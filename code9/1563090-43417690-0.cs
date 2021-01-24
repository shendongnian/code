    {
      string path=@"c:\directory\file.csv";
      string newPath=@"c:\directory\newFile.csv"
      using(StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open))) // no need for 2 usings
      using (FileStream aFStream = new FileStream (newPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
      {
        string line;
        string[] columns;
        {
          while((line = sr.ReadLine()) != null)
          {
            columns = line.Split(',');
            using (StreamWriter sw = new StreamWriter(aFStream))
            {
              sw.WriteLine(columns[13] + ',' + columns[10] + ',' + columns[16]);
              sw.Flush();
              sw.WriteLine(sw.NewLine);
            }
          }
        }
      }
    }
    

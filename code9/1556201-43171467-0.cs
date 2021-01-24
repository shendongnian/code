    public void iniSets(int dataSet)
    {
      DirectoryInfo dataColumns = new DirectoryInfo(@"SesmicData\");//Assuming Test is your Folder
      FileInfo[] Files = dataColumns.GetFiles($"*{dataSet}.txt"); //Getting Text files
      foreach (FileInfo file in Files)
      {
        using (StreamReader sr = new StreamReader(file.FullName))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            if (file.Name.StartsWith("column_a"))
            {
              // parse column A data per data type and store where it needs to be stored
            }
            else if (file.Name.StartsWith("column_b"))
            {
              // parse column B data per data type and store where it needs to be stored
            }
          }
        }
      }
    }

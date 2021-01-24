    string line;
    string[] lines = new string[]{"",""};
    int index = 0;
    using ( StreamReader reader = new StreamReader(File.OpenRead("C:\\test.log")) )
    {
       while ( ( line = reader.ReadLine() ) != null )
       {
           lines[index] = line;
           index = 1-index;
       }
    }
    // Last Line -1 = lines[index]
    // Last line    = lines[1-index]

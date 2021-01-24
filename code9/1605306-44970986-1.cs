    Dictionary<string,int> lineCount = new Dictionary<string,int>();
    string line;
    // Read the file and display it line by line.
    using(System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt"))
    {
       while((line = file.ReadLine()) != null)
       {
          string value = DiscoverFreq(line);
          lineCount[value] += 1;
        }
    }

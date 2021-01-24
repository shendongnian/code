    var temp = File.ReadAllLines(@"C:\myFile.csv");
    public List<MyMappedCSVFile>() myExtraction = new List<MyMappedCSVFile>();
    foreach(string line in temp)
    {
      var delimitedLine = line.Split('\t'); //set ur separator, in this case tab
      myExtraction.Add(new MyMappedCSVFile(delimitedLine[0], delimitedLine[3]));
    }

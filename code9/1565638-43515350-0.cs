    var reader = new StreamReader("sourcePath");
    string[] allLines = reader.ReadToEnd()
                          .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    var colList = new List<string>(allLines[0].Split(','));
    var isExist=colList.Exists(s => s == "Your Column Name") 

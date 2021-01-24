    Dictionary<string, string> myDictionary = new Dictionary<string, string>(); // make this global
    var file = File.ReadAllLines(path);
    List<string> TempList = new List<string>(file);
    foreach(var line in TempList){
         string[] TempArray = line.Split('=');
         myDictionary.Add(TempArray[0],TempArray[1]);
    }

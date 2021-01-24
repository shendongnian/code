    var regionInfo = RegionInfo.CurrentRegion;
    var name = regionInfo.Name;
    var englishName = regionInfo.EnglishName;
    var displayName = regionInfo.DisplayName;
    
    Console.WriteLine("Name: {0}", name);
    Console.WriteLine("EnglishName: {0}", englishName);
    Console.WriteLine("DisplayName: {0}", displayName);   

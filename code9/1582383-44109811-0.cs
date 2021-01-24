    string line = "Some text before MyFile.txt some other text after";
    
    //If you look for path:
    //var array = Path.GetInvalidPathChars().Cast<char>().ToList();
    
    //If you look for file name
    var array = Path.GetInvalidFileNameChars().Cast<char>().ToList();
    array.Add(' ');
    
    var potentialFileNames = line.Split(array.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                 .Where(i => i.Contains('.')).ToList();
     //potentialFileNames[0] = "MyFile.txt"

    var line = reader.ReadLine();
    
    if(string.IsNullOrEmpty())//<--empty row
        continue;//<--ignore, or else add empty values to your in-memory lists
    
    var values = line.Split(',');
    
    listA.Add(new string[] { values.length > 0 ? values[0] : string.Empty });
    listB.Add(new string[] { values.length > 1 ? values[1] : string.Empty });
    listC.Add(new string[] { values.length > 2 ? values[2] : string.Empty });
    
    //or simply
    
    if(values.length < 3)
        continue;//<--ignore, or else add empty values to your in-memory lists

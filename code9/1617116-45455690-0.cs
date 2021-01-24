    string makroexp = @"#define\s+(\w+).*\\(?:\s*{((?:.*\\\s+)*)})?";
    string[] lines = File.ReadAllLines(Path.GetFullPath(....));
    string temporarystring = "";
    
    string[] keys = new string[0];
    string[] values = new string[0];
    
    foreach (string line in lines)
    {
    	temporarystring += line;
    	temporarystring += "\n";
    }
    
    
    try
    {
    	makrodic.Add(makro.Groups[1].Value, makro.Groups[2].Value);
    }
    catch
    {
    	//Already added
    }

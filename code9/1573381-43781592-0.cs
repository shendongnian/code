    //read last char:
    byte lastChar1 = System.IO.File.ReadAllBytes(filePath).Last();
    
    //if a file is bigger, there is no need to read it all to just check the last char:
    var fs = System.IO.File.OpenRead(filePath);
    fs.Position = fs.Length-1;
    var lastChar2 = fs.ReadByte();
    fs.Close();

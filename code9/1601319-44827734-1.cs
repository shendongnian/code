    // our dummy scannerParameters objects
    var parameters = new ScannerParameters();
    
    // let's serialize it all into one string
    string output = JsonConvert.SerializeObject(paramaters);
    // let's write all that into a settings text file
    System.IO.File.WriteAllText("parameters.txt", output);
    // let's read the file next time we need it
    string parametersJson = System.IO.File.ReadAllText("parameters.txt);
    // let's deserialize the parametersJson
    ScannerParameters scannerParameters = JsonConvert.DeserializeObject<ScannerParameters>(parametersJson);
    

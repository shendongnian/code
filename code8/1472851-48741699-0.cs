    using ATL.AudioData;
    
    // Load audio file information into memory
    Track theTrack = new Track(audioFilePath);
    
    // Display BEXT data
    string originator = "", engineer = "", scene = "";
    if (theTrack.AdditionalFields.ContainsKey("bext.originator")) originator = theTrack.AdditionalFields["bext.originator"];
    
    System.Console.WriteLine("Originator : " + originator);

    //var input=File.ReadAllText("someFile.ctl");
    var input=@"<DTSControl>
    <Version>1.0</Version>
    <AddressType>DTS</AddressType>
    <MessageType>Data</MessageType>
    <From_DTS>x26OT075</From_DTS>
    <To_DTS>x26OT075</To_DTS>
    <Subject>ECDS Submission</Subject>
    <LocalId>TEST-delta.jsonl</LocalId>
    <WorkflowId>SUS_CDS</WorkflowId>
    <Encrypted>N</Encrypted>
    <Compress>Y</Compress>
    </DTSControl>";
    Regex reg = new Regex(@".*<LocalId>(.*?)</LocalId>.*");
    // Check, if it exists in the string
    if(reg.IsMatch(input)){
        // Get all the Matches (here: 1)
        var mtch=reg.Matches(input);
        // collect the good stuff from the capture group
        Console.WriteLine(mtch[0].Groups[1].Value);
    }

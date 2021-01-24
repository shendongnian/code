    ...
    pingProc.WaitForExit();
            
    var reader = pingProc.StandardOutput;
    var regex = new Regex( @".+?\s+=\s+(\d+)(,|$)" );
            
    var sent = 0;
    var recieved = 0;
    var lost = 0;
    string result;
    while ( ( result = reader.ReadLine() ) != null )
    {
        if ( String.IsNullOrEmpty( result ) )
           continue;
        var match = regex.Matches( result );
        if ( match.Count != 3 )
           continue;
        sent = Int32.Parse( match[0].Groups[1].Value );
        recieved = Int32.Parse( match[1].Groups[1].Value );
        lost = Int32.Parse( match[2].Groups[1].Value );
    }
    var success = sent > 0 && sent == recieved && lost == 0;

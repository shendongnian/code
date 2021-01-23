    string outputValue = "";
    var lines = System.IO.File.ReadLines( path );
    foreach( var thisLine in  lines) 
    {
       if( thisLine.Contains( inputValue ) ) 
       {
          // Get the answer from the next line
          var answer = lines.Take( 1 ).FirstOrDefault();
          if( !string.IsNullOrWhiteSpace( answer ) ) 
          {
             outputValue = answer;
          }
       }
    }

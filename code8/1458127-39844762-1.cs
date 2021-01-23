    int word4Idx = -1;
    int word = 0;
    bool inWS = true;
    for(int i = 0; i < line.Length && word < 4; i++) {
        
        if( inWS ) {
            if( !Char.IsWhitespace( line[i] ) ) {
                word++;
                word4IDx = i;
                inWS = false;
            }
        }
        else {
            inWS = Char.IsWhitespace( line[i] );
        }
        
    }
    if( word4Idx > -1 && word4Idx < line.Length ) return line.Substring( 0, word4Idx );
    return line;

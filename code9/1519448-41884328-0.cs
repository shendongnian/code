    Dictionary<String,String> dict = new Dictionary<String,String>();
    using( StreamReader rdr = new StreamReader( File.Open("filename.txt") ) ) {
        
        String line;
        while( (line = rdr.ReadLine()) != null ) {
            
            // assuming that values are not surrounded in quotes and are separated by a space character:
            
            Int32 spaceIdx = line.IndexOf(' ');
            if( spaceIdx == 0 || spaceIdx == -1 ) continue; // skip invalid lines
            String key   = line.Substring( 0, spaceIdx - 1 );
            String value = line.Substring( spaceIdx );
            
            dict.Add( key, value );
        }
    }
    

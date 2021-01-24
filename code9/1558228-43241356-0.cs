    using( IDataReader rdr = command.ExecuteReader() ) {
        
        while( rdr.Read() ) {
            
            String value = rdr.IsDBNull( someColumnIndex ) ? null : rdr.GetString( someColumnIndex );
        }
    }

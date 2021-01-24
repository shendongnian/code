    Object[] values = ...
    SqlCommand cmd = connection.CreateCommand();
    StringBuilder sb = new StringBuilder(" SELECT * FROM foo WHERE x IN (");
    for( Int32 i = 0; i < values.Length; i++ ) {
        if( i > 0 ) sb.Append(", ");
        String name = " @param" + i.ToString( CultureInfo.InvariantCulture );
        sb.Append( name );
        cmd.Parameters.Add( name ).Value = values[i];
    }
    sb.Append( ")" );
    cmd.CommandText = sb.ToString();

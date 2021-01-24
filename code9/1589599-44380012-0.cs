    StringBuilder sb = new StringBuilder("INSERT INTO [table] (");
    var safeNames = dict.Select( pair => new { ColumnName = pair.Key.Replace("[", "").Replace("]", ""), Value = pair.Value } ); // assuming this is sufficient to prevent injection
    
    Boolean first = true;
    foreach( var pair in safeNames  ) {
        
        if( !first ) sb.Append(", ");
        first = false;
        
        sb.Append("[");
        sb.Append( pair.ColumnName );
        sb.Append("]");
    }
    sb.Append( " ) VALUES ( " );
    first = false;
    foreach( var pair in safeNames ) {
        
        if( !first ) sb.Append(", ");
        first = false;
        
        sb.Append("@");
        sb.Append( pair.ColumnName );
    }
    sb.Append( ");" );
    using( SqlCommand cmd = connection.CreateCommand() ) {
        
        cmd.CommandText = sb.ToString();
        foreach( var pair in safeNames ) {
            cmd.Parameters.Add( '@' + pair.ColumnName ).Value = pair.Value;
        }
        cmd.ExecuteNonQuery();
    }

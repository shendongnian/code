    var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList( );
    var copy = new List<PropertyInfo>( ):
    
    foreach( var p in props )
    {
        if( p.GetCustomAttribute() ?? new JsonPropertyAttribute()).Value == value.Value )
             copy.Add(p);
    }

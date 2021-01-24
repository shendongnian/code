    var l1 = new List<string> { "A", "B", "C" };
    var l2 = new List<string> { "D", "E" };
    
    var result = new List<string>( l1.Concat( l2 ) );
    
    foreach( string s1 in l1 )
    {
        foreach( string s2 in l2 )
        {
            result.Add( $"{s1},{s2}" );
        }
    }

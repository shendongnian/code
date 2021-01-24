        // By header name
    var field = csv["HeaderName"];
        // Gets field by position returning string
    var field = csv.GetField( 0 );
    
   
     // Gets field by position returning int
        var field = csv.GetField<int>( 0 );
    
    // Gets field by header name returning bool
    var field = csv.GetField<bool>( "IsTrue" );
    
    // Gets field by header name returning object
    var field = csv.GetField( typeof( bool ), "IsTrue" );

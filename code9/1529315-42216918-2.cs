    var codes = File.ReadAllLines( "Codes.txt" );
    var countries = File.ReadAllLines( "Countries.txt" );
    
    var lines = new List<string>( codes.Length );
    for( int i = 0; i < codes.Length; i++ ) {
       lines.Add( $"Code = {codes[ i ]}" + Environment.NewLine + $"Country = {countries[ i ]}" );
    }
    
    File.WriteAllLines( "Result.txt",  lines);

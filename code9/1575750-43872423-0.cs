    string[] stringToCheck = { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado" };
    //Some test lines
    string[] lines = { "sadnaskjd Alabama", "sadasd Arizona", "asdasdaer" };
    //A bool telling me if I found anything, 
    //you could skip the bool and just use else in the foreach :)
    bool contains = false;
  
    foreach ( var check in stringToCheck )
    {
        if ( lines.Any( l => l.Contains( check ) ) )
        {
            Console.WriteLine( "Found substring" );
            Console.WriteLine( s );
            contains = true;
        }  
    }
    
    if ( contains == false )
    {
        Console.WriteLine("Could not find substring");
        Console.ReadLine();
    }

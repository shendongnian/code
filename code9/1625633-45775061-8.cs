    double [,,] arr3_alt = new double[ 2, 6, 9 ];
    
    for (int i = 0; i < 2; i++)
    for (int j = 0; j < 6; j++)
    for (int k = 0; k < 9; k++) {
        arr3_alt[ i, j, k ] = arr3[ k, j, i ];
    }
    
    Console.WriteLine( arr3_alt[ 0, 0, 0 ] );
    Console.WriteLine( arr3_alt[ 1, 0, 0 ] );
    Console.WriteLine( arr3_alt[ 0, 1, 0 ] );
    Console.WriteLine( arr3_alt[ 1, 1, 0 ] );
    Console.WriteLine( "..." );
    Console.WriteLine( arr3_alt[ 0, 4, 8 ] );
    Console.WriteLine( arr3_alt[ 1, 4, 8 ] );
    Console.WriteLine( arr3_alt[ 0, 5, 8 ] );
    Console.WriteLine( arr3_alt[ 1, 5, 8 ] );

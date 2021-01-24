    int[,] matrix = new int[,]
    {
        { 0, 1, 1, 2 }, 
        { 0, 5, 0, 0 },
        { 2, 0, 3, 3 },
    };
    Int32 sum = 0;
    // Using row-major-order, so the indexer is [y,x] instead of the traditional [x,y]
    for( int y = 0; y <= matrix.GetUpperBound(0); y++ )
    for( int x = 0; x <= matrix.GetUpperBound(1); x++ )
    {
        int cell = matrix[y,x];
        bool hasZeroAboveCurrentCell = y > 0 && matrix[y-1,x] != 0;
        if( cell != 0 && !hasZeroAboveCurrentCell )
        {
            sum += cell;
        }
    }
    Console.WriteLine( "Total: {0}", sum );

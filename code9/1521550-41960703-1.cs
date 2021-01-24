    int ExampleFunc( string userInput )
    {
        int nVal;
        if( int.TryParse( userInput, out nVal ) )
        {
            return Math.Abs( nVal );
        }
        else return 0;
    }

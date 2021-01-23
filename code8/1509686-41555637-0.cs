    void FiveTwo( int a, int b, int base ) {
        int n = base*10; // Number with all 2's & 5's and a 0 on the end
        if ( n+2<=b ) {
            FiveTwo(a,b,n+2);  // Find numbers bigger than n+2
            if ( a<=n+2 )
                Console.WriteLine( n+2 );  // Not too big to print
        }      
        if ( n+5<=b ) {
            FiveTwo(a,b,n+5);  // Find numbers bigger than n+5
            if ( a<=n+5 )
                Console.WriteLine( n+5 );  // Not too big to print
        } 
    }

        int[,] A = new int[2,3] { {1,2,3}, {4,5,6} };
        int[]  B = new int[6];
        Buffer.BlockCopy( A, 0, B, 0, sizeof(int) * 6 );  // A=src, B=dest, 0=offset, count=in-bytes
        WriteLine( "B[0] = " + B[0] + " A[0,0] = " + A[0,0] );
        WriteLine( "B[1] = " + B[1] + " A[0,1] = " + A[0,1] );
        WriteLine( "B[2] = " + B[2] + " A[0,2] = " + A[0,2] );
        WriteLine( "B[3] = " + B[3] + " A[1,0] = " + A[1,0] );
        WriteLine( "B[4] = " + B[4] + " A[1,1] = " + A[1,1] );
        WriteLine( "B[5] = " + B[5] + " A[1,2] = " + A[1,2] );

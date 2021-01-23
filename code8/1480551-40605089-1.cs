    [DllImport("testDll.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr GetBoard();
    [DllImport("testDll.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void FreeMemory(IntPtr ptr);
    public static ChessBoard GetChessBoard()
    {
        var boradPtr = GetBoard();
        var chessBoard = (ChessBoard)Marshal.PtrToStructure(boradPtr, typeof(ChessBoard));
        FreeMemory(boradPtr);
        return chessBoard;
    }

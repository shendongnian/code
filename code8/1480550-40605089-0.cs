    [DllImport("testDll.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void GetBoard2(ref ChessBoard  ptr);
    public static ChessBoard GetChessBoard()
    {
        ChessBoard chess = new ChessBoard();
        GetBoard2(ref chess);
        return chess;
    }

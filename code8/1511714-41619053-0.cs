    for (int i = 1; i < 8; i++)
    {
        if (x + i < board.GetLength(0) && board[x + i, y].Equals(blackColor))
            checkmateList.AddLast(placementBoard[x + i, y]); //Moving Right
    
        if (x - i >= 0 && board[x - i, y].Equals(blackColor))
            checkmateList.AddLast(placementBoard[x - i, y]); //Moving Left
    
        if (y + i < board.GetLength(1) && board[x, y + i].Equals(blackColor))
            checkmateList.AddLast(placementBoard[x, y + i]); //Moving Down
    }

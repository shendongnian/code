    class SudokuGameBoard
    {
        IProgress<BoardStatus> _progress;
        public SudokuGameBoard(IProgress<BoardStatus> progress)
        {
            _progress=progress;
        }
        public void SetToken(Int32 line, Int32 column, Token newToken)
        {
            array[line, column] = newToken;
            _progress.Report(new BoardStatus(line, column, newToken));
        } 
    }

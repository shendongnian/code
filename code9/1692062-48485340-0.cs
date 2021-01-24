    public byte getBoardValue(int index) {
      if (index >= 0 && index < Board.Length)
        return _board[index];
      else
        return 3;
    }
    public void setBoardValue(int index, byte value) {
      if (index >= 0 && index < Board.Length)
            _board[index] = value;
    }

    class BoardStatus
    {
        public int Line {get;}
        public int Column {get;}
        public Token Token {get;}
        public BoardStatus(int line, int column,Token token)
        {
            Line=line;
            Column=column;
            this.Token=token;
        }
    }

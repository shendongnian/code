    class RowCol
    {
        private int _row;
        private int _col;
    
        public int Row
        {
            get { return _row; }
            set
            {
                // Row is of the form <digit><letter
                // giving you 260 possible values.
                if (value < 0 || value > 259)
                    throw new ArgumentOutOfRangeException();
                _row = value;
            }
        }
    
        public int Col
        {
            get { return _col; }
            set
            {
                // Col is <letter><digit><letter>,
                // giving you 6,760 possible values
                if (value < 0 || value > 6759)
                    throw new ArgumentOutOfRangeException();
                _col = value;
            }
        }
    
        public string RowString
        {
            get
            {
                // convert Row value to string
                int r, c;
                r = Math.DivMod(_row, 26, out c);
                r += '0';
                c += 'A';
                return string.Concat((char)r, (char)c);
            }
            set
            {
                // convert string to number.
                // String is of the form <letter><digit>
                if (string.IsNullOrEmpty(value) || value.Length != 2
                    || !Char.IsDigit(value[0] || !Char.IsUpper(value[1]))
                    throw new ArgumentException();
                _row = 26*(value[0]-'0') + (value[1]-'A');
            }
        }
    
        public string ColString
        {
            get
            {
                int left, middle, right remainder;
                left = Math.DivRem(_col, 260, out remainder);
                middle = Math.DivRem(remainder, 26, out right);
                left += 'A';
                middle += '0';
                right += 'A';
                return string.Concat((char)left, (char)middle, (char)right);
            }
    
            set
            {
                // Do standard checking here to make sure it's in the right form.
                if (string.IsNullOrEmpty(value) || value.Length != 3
                    || !Char.IsUpper(value[0] || !Char.IsDigit(value[1]) || !Char.IsUpper(value[2]))
                    throw new ArgumentException();
    
                _col = 260*(value[0] - 'A');
                _col += 26*(value[1] - '0');
                _col += value[2] - 'A';
            }
        }
    
        public override string ToString()
        {
            return RowString + '-' + ColString;
        }
    
        public RowCol(int row, int col)
        {
            Row = _row;
            Col = _col;
        }
    
        public RowCol(string row, string col)
        {
            RowString = row;
            RowString = col;
        }
    }

    class Table: IEnumerable
    {
        private Row[] _rows;
    
        public Table(params Row[] rows)
        {
            this._rows = rows;
    
        }
    
        public IEnumerator GetEnumerator()
        {
            foreach (var row in _rows)
            {
                yield return row;
            }
        }
    }

    class GridManager<T>
    {
        private T[,] _matrix;
    
        public GridManager(int rows, int columns)
        {
            _matrix = new T[rows, columns];
        }
    
        public T this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }
    }

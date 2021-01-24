    public class HugeMatrix<T> : IDisposable
        where T : struct
    {
        public IntPtr Pointer
        {
            get { return pointer; }
        }
        private IntPtr pointer = IntPtr.Zero;
        public int NRows
        {
            get { return Transposed ? _NColumns : _NRows; }
        }
        private int _NRows = 0;
        public int NColumns
        {
            get { return Transposed ? _NRows : _NColumns; }
        }
        private int _NColumns = 0;
        public bool Transposed
        {
            get { return _Transposed; }
            set { _Transposed = value; }
        }
        private bool _Transposed = false;
        private ulong b_element_size = 0;
        private ulong b_row_size = 0;
        private ulong b_size = 0;
        private bool disposed = false;
        public HugeMatrix()
            : this(0, 0)
        {
        }
        public HugeMatrix(int nrows, int ncols, bool transposed = false)
        {
            if (nrows < 0)
                throw new ArgumentException("The number of rows can not be negative");
            if (ncols < 0)
                throw new ArgumentException("The number of columns can not be negative");
            _NRows = transposed ? ncols : nrows;
            _NColumns = transposed ? nrows : ncols;
            _Transposed = transposed;
            b_element_size = (ulong)(Marshal.SizeOf(typeof(T)));
            b_row_size = (ulong)_NColumns * b_element_size;
            b_size = (ulong)_NRows * b_row_size;
            pointer = Marshal.AllocHGlobal((IntPtr)b_size);
            disposed = false;
        }
        public HugeMatrix(T[,] matrix, bool transposed = false)
            : this(matrix.GetLength(0), matrix.GetLength(1), transposed)
        {
            int nrows = matrix.GetLength(0);
            int ncols = matrix.GetLength(1);
            for (int i1 = 0; i1 < nrows; i1++)
                for (int i2 = 0; i2 < ncols; i2++)
                    this[i1, i2] = matrix[i1, i2];
        }
        public void Dispose()
        {
            if (!disposed)
            {
                Marshal.FreeHGlobal(pointer);
                _NRows = 0;
                _NColumns = 0;
                _Transposed = false;
                b_element_size = 0;
                b_row_size = 0;
                b_size = 0;
                pointer = IntPtr.Zero;
                disposed = true;
            }
        }
        public void Transpose()
        {
            _Transposed = !_Transposed;
        }
        public T this[int i_row, int i_col]
        {
            get
            {
                IntPtr p = getAddress(i_row, i_col);
                return (T)Marshal.PtrToStructure(p, typeof(T));
            }
            set
            {
                IntPtr p = getAddress(i_row, i_col);
                Marshal.StructureToPtr(value, p, true);
            }
        }
        private IntPtr getAddress(int i_row, int i_col)
        {
            if (disposed)
                throw new ObjectDisposedException("Can't access the matrix once it has been disposed");
            if (i_row < 0)
                throw new IndexOutOfRangeException("Negative row indices are not allowed");
            if (i_row >= NRows)
                throw new IndexOutOfRangeException("Row index is out of bounds of this matrix");
            if (i_col < 0)
                throw new IndexOutOfRangeException("Negative column indices are not allowed");
            if (i_col >= NColumns)
                throw new IndexOutOfRangeException("Column index is out of bounds of this matrix");
            int i1 = Transposed ? i_col : i_row;
            int i2 = Transposed ? i_row : i_col;
            ulong p_row = (ulong)pointer + b_row_size * (ulong)i1;
            IntPtr p = (IntPtr)(p_row + b_element_size * (ulong)i2);
            return p;
        }
    }

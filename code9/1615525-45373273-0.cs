    public class Table<T>
    {
        private readonly List<List<T>> columns;
        public Table()
        {
            columns = new List<List<T>>();
        }
        public IEnumerable<IEnumerable<T>> Columns => columns.Select(c => c.Select(r => r));
        public IEnumerable<IEnumerable<T>> Rows
        {
            get
            {
                IEnumerable<T> getRow(int index)
                {
                    foreach (var c in columns)
                    {
                        yield return c[index];
                    }
                }
                for (var row = 0; row < Count; row++)
                {
                    yield return getRow(row);
                }
            }
        }
        public int Count => columns.Count == 0 ? 0 : columns[0].Count;
        public T this[int row, int column]
        {
            get
            {
                return columns[column][row];
            }
            set
            {
                columns[column][row] = value;
            }
        }
        public void AddRow()
        {
            foreach (var c in columns)
            {
                c.Add(default(T));
            }
        }
        public void AddRow(params T[] values)
        {
            if (values.Length != columns.Count)
                throw new ArgumentException();
            for (var column = 0; column < columns.Count; column++)
            {
                columns[column].Add(values[column]);
            }
        }
        public void DeleteRow(int row)
        {
            foreach (var c in columns)
            {
                c.RemoveAt(row);
            }
        }
        public void AddColumn()
        {
            var newColumn = new List<T>();
            for (var rows = 0; rows < Count; rows++)
            {
                newColumn.Add(default(T));
            }
            columns.Add(newColumn);
        }
        public override string ToString()
            => string.Join(Environment.NewLine, Rows.Select(c => string.Join(";", c)));

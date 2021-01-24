    class Matrix : IEnumerable
    {
        List<int[]> rowList = new List<int[]>();
        public void Add(params int[] row)
        {
            rowList.Add(row);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return rowList.GetEnumerator();
        }
    }

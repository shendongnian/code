    class Set : List<int>
    {
        public new void Add(int tmp)
        {
            base.Add(tmp);
        }
    }
    Set myset = new Set();
    myset.Add(43);

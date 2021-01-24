    class Set : List<int>
    {
        public new void Add(int tmp)
        {
            // custom logic here
            base.Add(tmp);
        }
    }
    Set myset = new Set();
    myset.Add(43);

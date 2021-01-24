    class ArrayLess : IEnumerable<string>
    {
        SortedList<string, dynamic> list = new SortedList<string, dynamic>();
        public void Add(dynamic key, dynamic val) => list[key.ToString()] = val;
        public dynamic this[dynamic key] => list[key.ToString()];
        public IEnumerator<string> GetEnumerator() => list.Keys.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MyEnumerable<T> : IEnumerable<T>
    {
        private List<T> _list;
        public MyEnumerable()
        {
            _list = new List<T>();
        }
        public void Add(T value)
        {
            _list.Add(value);
        }
        public bool Remove(T value)
        {
            return _list.Remove(value);
        }
        public bool Exists(Predicate<T> value)
        {
            return _list.Exists(value);
        }
        public bool Contains(T value)
        {
            return _list.Contains(value);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (i == 2)
                {
                    i++;
                    yield return _list[i];
                    yield return _list[i-1];
                }
                else
                {
                    yield return _list[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (i == 3)
                {
                    yield return _list[i + 1];
                    yield return _list[i];
                    i += 2;
                }
                else
                {
                    yield return _list[i];
                    i++;
                }
            }
        }
    }

    class ListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
          return  x.SequenceEqual(y);
        }
        public int GetHashCode(IList<int> obj)
        {
            throw new NotImplementedException();
        }
    }

    class MyWordCollection : IQueryable<Word>, IQueryable,
        IEnumerable<Word>, IEnumerable
    {
        public Type ElementType { get { return typeof(Word); } }
        public IQueryProvider Provider { get; private set; }
        public Expression Expression { get; private set; }
        #region enumerators
        public IEnumerator<Word> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<Word>>
                (Expression)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion enumerators
    }

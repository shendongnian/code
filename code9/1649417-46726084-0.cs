    public MyList<T> : IList<T>
    {
        private IList<T> innerList;
        public MyList(IList<T> innerList) { this.innerList = innerList; }
        // valid operations are just delegated to the inner list...
        public int Count { get { return innerList.Count; } }
        // those you want to prohibit either do nothing or throw - depends on your desired outcome
        public void Add(T item) { return; }
        // and so on ...
    }

        class GroupViewModel<T> : IEnumerable<T>
    {
        public IEnumerable<T> Items { get; private set; }
        public string Name { get; private set; }
        public string Id { get; private set; }
        public GroupViewModel(string name,string id, IEnumerable<T> items)
        {
            this.Id = id;
            this.Name = name;
            this.Items = items;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
    }

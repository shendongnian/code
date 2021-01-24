    class Foo
    {
        private volatile List<string> lockedList = new List<string>();
        public void ReplaceList(IEnumerable<string> items)
        {
            lockedList = new List<string>(items);
        }
        public void Add(string newItem)
        {
            var localList = lockedList;
            lock (localList)
            {
                localList.Add(newItem);
            }
        }
        public void Contains(string item)
        {
            var localList = lockedList;
            lock (localList)
            {
                localList.Contains(item);
            }
        }
    }

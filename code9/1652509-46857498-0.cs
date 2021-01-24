    class Foo
    {
        private List<string> lockedList = new List<string>();
        public void ReplaceList(IEnumerable<string> items)
        {
            lock (lockedList)
            {
                lockedList.Clear();
                lockedList.AddRange(items);
            }
        }
        public void Add(string newItem)
        {
            lock (lockedList)
            {
                lockedList.Add(newItem);
            }
        }
        public void Contains(string item)
        {
            lock (lockedList)
            {
                lockedList.Contains(item);
            }
        }
    }

    class Foo
    {
        List<string> lockedList = new List<string>();
        public void ReplaceList(List<string> newList)
        {
            lock (lockedList) 
            {
                lockedList = newList;
            }
        }
        public void Add(string newItem)
        {
            lock(lockedList)
            {
                lockedList.Add(newItem);
            }
        }
    }

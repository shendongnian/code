    public class StringList : IStringList
    {
        private List<string> items;
        private const string ConversionErrorMessageFormatString = "Cannot convert from {0} to {1}.";
        public int Capacity { get => items.Capacity; set => items.Capacity = value; }
        public bool IsFixedSize { get => ((IList)items).IsFixedSize; }
        public int Count { get => items.Count; }
        public bool IsReadOnly { get => ((IList<string>)items).IsReadOnly; }
        public bool IsSynchronized { get => ((ICollection)items).IsSynchronized; }
        public string this[int index] { get => items[index]; set => items[index] = value; }
        object IList.this[int index] { get => ((IList)items)[index]; set => ((IList)items)[index] = value; }
        object ICollection.SyncRoot { get => ((ICollection)items).SyncRoot; }
        public StringList()
        {
            items = new List<string>();
        }
        public StringList(int capacity)
        {
            items = new List<string>(capacity);
        }
        public StringList(IList list)
        {
            if (!(list is IList<string>))
            {
                throw new ArgumentException(
                    String.Format(ConversionErrorMessageFormatString, 
                    list.GetType().ToString(),
                    this.GetType().ToString()), 
                    nameof(list));
            }
            items = list as List<string>;
        }
        public StringList(IEnumerable collection)
        {
            if (!(collection is IEnumerable<string>))
            {
                throw new ArgumentException(
                    String.Format(ConversionErrorMessageFormatString, 
                    collection.GetType().ToString(),
                    this.GetType().ToString()), 
                    nameof(collection));
            }
            items = new List<string>(collection as IEnumerable<string>);
        }
        public void Add(string item)
        {
            items.Add(item);
        }
        int IList.Add(object item)
        {
            return ((IList)items).Add(item);
        }
        public void AddRange(IEnumerable collection)
        {
            items.AddRange(collection as IEnumerable<string>);
        }
        public int BinarySearch(int index, int count, string item, IComparer comparer)
        {
            return items.BinarySearch(index, count, item, (IComparer<string>)comparer);
        }
        public int BinarySearch(string item)
        {
            return items.BinarySearch(item);
        }
        public int BinarySearch(string item, IComparer comparer)
        {
            return items.BinarySearch(item, (IComparer<string>)comparer);
        }
        public void Clear()
        {
            items.Clear();
        }
        public bool Contains(string item)
        {
            return items.Contains(item);
        }
        bool IList.Contains(object item)
        {
            return ((IList)items).Contains(item);
        }
        public void CopyTo(string[] array)
        {
            items.CopyTo(array);
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            ((ICollection)items).CopyTo(array, arrayIndex);
        }
        public void CopyTo(int index, string[] array, int arrayIndex, int count)
        {
            items.CopyTo(index, array, arrayIndex, count);
        }
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
        
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public StringList GetRange(int index, int count)
        {
            return new StringList(items.GetRange(index, count));
        }
        public int IndexOf(string item)
        {
            return items.IndexOf(item);
        }
        int IList.IndexOf(object item)
        {
            return ((IList)items).IndexOf(item);
        }
        public int IndexOf(string item, int index)
        {
            return items.IndexOf(item, index);
        }
        public int IndexOf(string item, int index, int count)
        {
            return items.IndexOf(item, index, count);
        }
        public void Insert(int index, string item)
        {
            items.Insert(index, item);
        }
        void IList.Insert(int index, object item)
        {
            ((IList)items).Insert(index, item);
        }
        public void InsertRange(int index, IEnumerable collection)
        {
            items.InsertRange(index, (IEnumerable<string>)collection);
        }
        public int LastIndexOf(string item)
        {
            return items.LastIndexOf(item);
        }
        public int LastIndexOf(string item, int index)
        {
            return items.LastIndexOf(item, index);
        }
        public int LastIndexOf(string item, int index, int count)
        {
            return items.LastIndexOf(item, index, count);
        }
        public bool Remove(string item)
        {
            return items.Remove(item);
        }
        void IList.Remove(object item)
        {
            ((IList)items).Remove(item);
        }
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
        public void RemoveRange(int index, int count)
        {
            items.RemoveRange(index, count);
        }
        public void Reverse()
        {
            items.Reverse();
        }
        public void Reverse(int index, int count)
        {
            items.Reverse(index, count);
        }
        public void Sort()
        {
            items.Sort();
        }
        public string[] ToArray()
        {
            return items.ToArray();
        }
        public void TrimExcess()
        {
            items.TrimExcess();
        }
    }

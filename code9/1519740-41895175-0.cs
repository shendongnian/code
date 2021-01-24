    public class FileStructList : IList<long>
    {
        Stream baseStream;
        BinaryReader reader;
        int length;
        public FileStructList(string FileName)
        {
            baseStream = File.OpenRead(FileName);
            reader = new BinaryReader(baseStream);
            length = (int)(baseStream.Length / 24);
        }
        public long this[int index]
        {
            get
            {
                baseStream.Seek(24 * index, SeekOrigin.Begin);
                return reader.ReadInt64();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public int Count
        {
            get
            {
                return length;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        public void Add(long item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(long item)
        {
            return BinarySearchIndexOf(item) != -1;
        }
        public void CopyTo(long[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<long> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int IndexOf(long item)
        {
            return BinarySearchIndexOf(item);
        }
        public void Insert(int index, long item)
        {
            throw new NotImplementedException();
        }
        public bool Remove(long item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Int32 BinarySearchIndexOf(long value, IComparer<long> comparer = null)
        {
            comparer = comparer ?? Comparer<long>.Default;
            Int32 lower = 0;
            Int32 upper = length - 1;
            while (lower <= upper)
            {
                Int32 middle = lower + (upper - lower) / 2;
                Int32 comparisonResult = comparer.Compare(value, this[middle]);
                if (comparisonResult == 0)
                    return middle;
                else if (comparisonResult < 0)
                    upper = middle - 1;
                else
                    lower = middle + 1;
            }
            return -1;
        }
    }

    public sealed class ShortList :IList<short>
    {
        private readonly byte[] _array;
        public short this[int index]
        {
            get { return (short)_array[index/2]<<8 | _array[index/2+1] ; }
        }
        public int Count
        {
            get { return _array.Length/2; }
        }
        ... many more methods in IList

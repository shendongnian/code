    public class AggregateDataReader : IDataReader
    {
        private readonly Queue<IDataReader> _readers;
        private IDataReader _current;
        public AggregateDataReader(IEnumerable<IDataReader> readers)
        {
            _readers = new Queue<IDataReader>(readers);
        }
        private bool AdvanceToNextReader()
        {
            _current?.Dispose();
            var moreReaders = _readers.Any();
            if (moreReaders) _current = _readers.Dequeue();
            return moreReaders;
        }
        public bool NextResult()
        {
            if (_current == null) return false;
            if (_current.NextResult()) return true;
            return AdvanceToNextReader();
        }
        public bool Read()
        {
            return _current.Read();
        }
        public void Dispose()
        {
            _current?.Dispose();
            while (_readers.Any()) _readers.Dequeue().Dispose();
        }
        public string GetName(int i)
        {
            return _current.GetName(i);
        }
      ... lots of these...
        public byte GetByte(int i)
        {
            return _current.GetByte(i);
        }
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return _currentGetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }
       ... etc...
        public void Close()
        {
            _current?.Close();
            while (_readers.Any()) _readers.Dequeue().Close();
        }
       ... etc...
    }

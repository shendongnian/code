    internal sealed class BufferStream : IDisposable
    {
        private byte[] _array = Array.Empty<byte>();
        private int _index = -1;
        private const int MaxArrayLength = 0X7FEFFFFF;
        public int Capacity => _array.Length;
        public int Length => _index + 1;
        public void WriteIntoDataWriterStreamAsync(IDataWriter writer)
        {
            // AsBuffer wont cause copy, its just wrapper around array.
            if(_index >= 0) writer.WriteBuffer(_array.AsBuffer(0, _index)); 
        }
        
        public void WriteBuffer(IBuffer buffer)
        {
            EnsureSize(checked((int) buffer.Length));
            for (uint i = 0; i < buffer.Length; i++)
            {
                _array[++_index] = buffer.GetByte(i);
            }
        }
        public void Flush()
        {
            Array.Clear(_array, 0, _index);
            _index = -1;
        }
        
        // list like resizing.
        private void EnsureSize(int additionSize)
        {
            var min = additionSize + _index;
            if (_array.Length <= min)
            {
                var newsize = (int) Math.Min((uint) _array.Length * 2, MaxArrayLength);
                if (newsize <= min) newsize = min + 1;
                Array.Resize(ref _array, newsize);
            }
        }
        public void Dispose()
        {
            _array = null;
        }
    }

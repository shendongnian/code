    class HDDArray : IEnumerable<int>, IDisposable
    {
        readonly FileStream stream;
        readonly BinaryWriter writer;
        readonly BinaryReader reader;
        public HDDArray(string file)
        {
            stream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);
        }
        public int this[int index]
        {
            get
            {
                stream.Position = index * 4;
                return reader.ReadInt32();
            }
            set
            {
                stream.Position = index * 4;
                writer.Write(value);
            }
        }
        public int Length
        {
            get
            {
                return (int)stream.Length / 4;
            }
        }
        public IEnumerator<int> GetEnumerator()
        {
            stream.Position = 0;
            while (reader.PeekChar() != -1)
                yield return reader.ReadInt32();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Dispose()
        {
            reader?.Dispose();
            writer?.Dispose();
            stream?.Dispose();
        }
    }

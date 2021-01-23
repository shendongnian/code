    [ProtoContract]
    class StreamObject
    {
        public StreamObject() : this(new MemoryStream()) { }
        public StreamObject(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException();
            this.StreamProperty = stream;
        }
        [ProtoIgnore]
        public Stream StreamProperty { get; set; }
        internal static event EventHandler OnDataReadBegin;
        internal static event EventHandler OnDataReadEnd;
        const int ChunkSize = 4096;
        [ProtoMember(1, IsPacked = false, OverwriteList = true)]
        IEnumerable<ByteBuffer> Data
        {
            get
            {
                if (OnDataReadBegin != null)
                    OnDataReadBegin(this, new EventArgs());
                while (true)
                {
                    byte[] buffer = new byte[ChunkSize];
                    int read = StreamProperty.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        break;
                    }
                    else if (read == buffer.Length)
                    {
                        yield return new ByteBuffer { Data = buffer };
                    }
                    else
                    {
                        Array.Resize(ref buffer, read);
                        yield return new ByteBuffer { Data = buffer };
                        break;
                    }
                }
                if (OnDataReadEnd != null)
                    OnDataReadEnd(this, new EventArgs());
            }
            set
            {
                if (value == null)
                    return;
                foreach (var buffer in value)
                    StreamProperty.Write(buffer.Data, 0, buffer.Data.Length);
            }
        }
    }
    [ProtoContract]
    struct ByteBuffer
    {
        [ProtoMember(1, IsPacked = true)]
        public byte[] Data { get; set; }
    }

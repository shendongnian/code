    class StreamWithProgress : Stream
    {
        // NOTE: for illustration purposes. For production code, one would want to
        // override *all* of the virtual methods, delegating to the base _stream object,
        // to ensure performance optimizations in the base _stream object aren't
        // bypassed.
        private readonly Stream _stream;
        private readonly IProgress<int> _readProgress;
        private readonly IProgress<int> _writeProgress;
        public StreamWithProgress(Stream stream, IProgress<int> readProgress, IProgress<int> writeProgress)
        {
            _stream = stream;
            _readProgress = readProgress;
            _writeProgress = writeProgress;
        }
        public override bool CanRead { get { return _stream.CanRead; } }
        public override bool CanSeek {  get { return _stream.CanSeek; } }
        public override bool CanWrite {  get { return _stream.CanWrite; } }
        public override long Length {  get { return _stream.Length; } }
        public override long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }
        public override void Flush() { _stream.Flush(); }
        public override long Seek(long offset, SeekOrigin origin) { return _stream.Seek(offset, origin); }
        public override void SetLength(long value) { _stream.SetLength(value); }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = _stream.Read(buffer, offset, count);
            _readProgress?.Report(bytesRead);
            return bytesRead;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
            _writeProgress?.Report(count);
        }
    }

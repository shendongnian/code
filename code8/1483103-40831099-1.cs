    public class EncodeStreamFilter : Stream, IDisposable
    {
        private Stream _baseStream;
        public EncodeStreamFilter(Stream responseFilter)
        {
            _baseStream = responseFilter;            
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            byte[] bufferBlock = new byte[count];
            Buffer.BlockCopy(buffer, offset, bufferBlock, 0, count);
            var encodedBytes = Encoding.UTF8.GetBytes(HttpUtility.HtmlEncode(Encoding.UTF8.GetString(bufferBlock)));
            
            _baseStream.Write(encodedBytes, 0, encodedBytes.Length);
        }
        public override bool CanRead
        {
            get
            {
                return _baseStream.CanRead;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return _baseStream.CanSeek;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return _baseStream.CanWrite;
            }
        }
        public override long Length
        {
            get
            {
                return _baseStream.Length;
            }
        }
        public override long Position
        {
            get
            {
                return _baseStream.Position;
            }
            set
            {
                _baseStream.Position = value;
            }
        }
        public override void Flush()
        {
            _baseStream.Flush();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _baseStream.Read(buffer, offset, count);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _baseStream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                _baseStream.Dispose();
            }
            base.Dispose(disposing);
        }
    }

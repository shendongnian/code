        class HugeMemoryStream : Stream
        {
            #region Fields
    
            private const int PAGE_SIZE = 1024000;
            private const int ALLOC_STEP = 1024;
    
            private byte[][] _streamBuffers;
    
            private int _pageCount = 0;
            private long _allocatedBytes = 0;
    
            private long _position = 0;
            private long _length = 0;
    
            #endregion Fields
    
            #region Internals
    
            private int GetPageCount(long length)
            {
                int pageCount = (int)(length / PAGE_SIZE) + 1;
    
                if ((length % PAGE_SIZE) == 0)
                    pageCount--;
    
                return pageCount;
            }
    
            private void ExtendPages()
            {
                if (_streamBuffers == null)
                {
                    _streamBuffers = new byte[ALLOC_STEP][];
                }
                else
                {
                    byte[][] streamBuffers = new byte[_streamBuffers.Length + ALLOC_STEP][];
    
                    Array.Copy(_streamBuffers, streamBuffers, _streamBuffers.Length);
    
                    _streamBuffers = streamBuffers;
                }
    
                _pageCount = _streamBuffers.Length;
            }
    
            private void AllocSpaceIfNeeded(long value)
            {
                if (value < 0)
                    throw new InvalidOperationException("AllocSpaceIfNeeded < 0");
    
                if (value == 0)
                    return;
    
                int currentPageCount = GetPageCount(_allocatedBytes);
                int neededPageCount = GetPageCount(value);
    
                while (currentPageCount < neededPageCount)
                {
                    if (currentPageCount == _pageCount)
                        ExtendPages();
    
                    _streamBuffers[currentPageCount++] = new byte[PAGE_SIZE];
                }
    
                _allocatedBytes = (long)currentPageCount * PAGE_SIZE;
    
                value = Math.Max(value, _length);
    
                if (_position > (_length = value))
                    _position = _length;
            }
    
            #endregion Internals
    
            #region Stream
    
            public override bool CanRead => true;
    
            public override bool CanSeek => true;
    
            public override bool CanWrite => true;
    
            public override long Length => _length;
    
            public override long Position
            {
                get { return _position; }
                set
                {
                    if (value > _length)
                        throw new InvalidOperationException("Position > Length");
                    else if (value < 0)
                        throw new InvalidOperationException("Position < 0");
                    else
                        _position = value;
                }
            }
    
            public override void Flush() { }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                int currentPage = (int)(_position / PAGE_SIZE);
                int currentOffset = (int)(_position % PAGE_SIZE);
                int currentLength = PAGE_SIZE - currentOffset;
    
                long startPosition = _position;
    
                while (count != 0 && _position < _length)
                {
                    if (currentLength > count)
                        currentLength = count;
    
                    Array.Copy(_streamBuffers[currentPage++], currentOffset, buffer, offset, currentLength);
    
                    offset += currentLength;
                    _position += currentLength;
                    count -= currentLength;
    
                    currentOffset = 0;
                    currentLength = PAGE_SIZE;
                }
    
                return (int)(_position - startPosition);
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        break;
    
                    case SeekOrigin.Current:
                        offset += _position;
                        break;
    
                    case SeekOrigin.End:
                        offset = _length - offset;
                        break;
    
                    default:
                        throw new ArgumentOutOfRangeException("origin");
                }
    
                return Position = offset;
            }
    
            public override void SetLength(long value)
            {
                if (value < 0)
                    throw new InvalidOperationException("SetLength < 0");
    
                if (value == 0)
                {
                    _streamBuffers = null;
                    _allocatedBytes = _position = _length = 0;
                    _pageCount = 0;
                    return;
                }
    
                int currentPageCount = GetPageCount(_allocatedBytes);
                int neededPageCount = GetPageCount(value);
    
                // Removes unused buffers if decreasing stream length
                while (currentPageCount > neededPageCount)
                    _streamBuffers[--currentPageCount] = null;
    
                AllocSpaceIfNeeded(value);
    
                if (_position > (_length = value))
                    _position = _length;
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                int currentPage = (int)(_position / PAGE_SIZE);
                int currentOffset = (int)(_position % PAGE_SIZE);
                int currentLength = PAGE_SIZE - currentOffset;
    
                long startPosition = _position;
    
                AllocSpaceIfNeeded(_position + count);
    
                while (count != 0)
                {
                    if (currentLength > count)
                        currentLength = count;
    
                    Array.Copy(buffer, offset, _streamBuffers[currentPage++], currentOffset, currentLength);
    
                    offset += currentLength;
                    _position += currentLength;
                    count -= currentLength;
    
                    currentOffset = 0;
                    currentLength = PAGE_SIZE;
                }
            }
    
            #endregion Stream
        }
    using ICSharpCode.SharpZipLib.GZip;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
                // HugeMemoryStrem Test
    
                string filename = @"gzip-filename.gz";
    
                HugeMemoryStream ms = new HugeMemoryStream();
    
                using (StreamWriter sw = new StreamWriter(ms, Encoding.UTF8, 16384, true))
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (GZipInputStream gzipStream = new GZipInputStream(fs))
                using (StreamReader sr = new StreamReader(gzipStream, Encoding.UTF8, false, 16384, true))
                {
                    for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
                        sw.WriteLine(line);
                }
    
                ms.Seek(0, SeekOrigin.Begin);
    
                using (StreamReader srm = new StreamReader(ms, Encoding.UTF8, false, 16384, true))
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (GZipInputStream gzipStream = new GZipInputStream(fs))
                using (StreamReader sr = new StreamReader(gzipStream, Encoding.UTF8, false, 16384, true))
                {
                    for (string line1 = sr.ReadLine(), line2 = srm.ReadLine(); line1 != null; line1 = sr.ReadLine(), line2 = srm.ReadLine())
                    {
                        if (line1 != line2)
                            throw new InvalidDataException();
                    }
                }

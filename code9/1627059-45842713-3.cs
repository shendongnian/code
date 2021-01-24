    internal sealed class CleanupTextReader : TextReader
    {
        private TextReader _in;
        internal CleanupTextReader(TextReader t)
        {
            _in = t;
        }
        public override void Close()
        {
            _in.Close();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable) _in).Dispose();
            }
        }
        public override int Peek()
        {
            return _in.Peek();
        }
        public override int Read()
        {
            while(true)
            {
                var result = _in.Read();
                if (result != '\u0000')
                {
                    return result;
                }
            }
        }
        private string CleanupString(string value)
        {
            if (string.IsNullOrEmpty(value) || value.IndexOfAny(new char['\u0000']) < 0)
            {
                return value;
            }
            var builder = new StringBuilder(value.Length);
            foreach (var ch in value)
            {
                if (ch != '\u0000')
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }
        private int CleanupBuffer(char[] buffer, int index, int count)
        {
            int adjustedCount = count;
            if (count > 0)
            {
                var readIndex = index;
                var writeIndex = index;
                while (readIndex < index + count)
                {
                    var ch = buffer[readIndex];
                    readIndex++;
                    if (ch == '\u0000')
                    {
                        adjustedCount--;
                    }
                    else
                    {
                        buffer[writeIndex] = ch;
                        writeIndex++;
                    }
                }
            }
            return adjustedCount;
        }
            
        public override int Read(char[] buffer, int index, int count)
        {
            while (true)
            {
                int reallyRead = _in.Read(buffer, index, count);
                if (reallyRead <= 0)
                {
                    return reallyRead;
                }
                int cleanRead = CleanupBuffer(buffer, index, reallyRead);
                if (cleanRead != 0)
                {
                    return cleanRead;
                }
            }
        }
        public override int ReadBlock(char[] buffer, int index, int count)
        {
            while (true)
            {
                int reallyRead = _in.ReadBlock(buffer, index, count);
                if (reallyRead <= 0)
                {
                    return reallyRead;
                }
                int cleanRead = CleanupBuffer(buffer, index, reallyRead);
                if (cleanRead != 0)
                {
                    return cleanRead;
                }
            }
        }
        public override string ReadLine()
        {
            return CleanupString(_in.ReadLine());
        }
        public override string ReadToEnd()
        {
            return CleanupString(_in.ReadToEnd());
        }
    }

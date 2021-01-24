        /// <summary>
        /// Get an array of long computing the total of each byte in the file. 
        /// The position of the array makes it possible to obtain the sum of the desired byte
        /// </summary>
        /// <example>
        /// COUNT OF 0xff
        /// var cnt = GetByteCount()[0xff]
        /// </example>
        public long[] GetByteCount()
        {
            if (IsOpen)
            {
                Position = 0;
                int bufferLength = 1048576; //1mb
                byte[] buffer;
                long[] storedCnt = new long[256];
                while (!EOF)
                {
                    buffer = new byte[bufferLength];
                    Read(buffer, 0, bufferLength);
                    foreach (byte b in buffer)
                        storedCnt[b]++;
                    Position += bufferLength;
                }
                return storedCnt;
            }
            return null;
        }
        /// <summary>
        /// Get or Set position in file. Return -1 when file is closed
        /// </summary>
        public long Position
        {
            get
            {
                if (IsOpen)
                    return _stream.Position <= _stream.Length ? _stream.Position : _stream.Length;
                return -1;
            }
            set
            {
                if (IsOpen)
                {
                    _stream.Position = value;
                }
            }
        }

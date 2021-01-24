        /// <summary>
        /// Get an array of long computing the total of each byte in the file. 
        /// The position of the array makes it possible to obtain the sum of the desired byte
        /// </summary>
        public long[] GetByteCount()
        {
            if (IsOpen)
            {
                const int bufferLenght = 1048576; //1mb
                var storedCnt = new long[256];
                Position = 0;
                while (!Eof)
                {
                    var testLenght = Length - Position;
                    var buffer = testLenght <= bufferLenght ? new byte[testLenght] : new byte[bufferLenght];
                    Read(buffer, 0, buffer.Length);
                    foreach (var b in buffer)
                        storedCnt[b]++;
                    Position += bufferLenght;
                }
                return storedCnt;
            }
            return null;
        }

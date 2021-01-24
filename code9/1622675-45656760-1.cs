        public int[] GetByteCount()
        {
            if (IsOpen)
            {
                Position = 0;
                int bufferLenght = 1048576; //1mb
                byte[] buffer;
                int[] storedCnt = new int[256];
                
                while (!EOF)
                {
                    buffer = new byte[bufferLenght];
                    Read(buffer, 0, bufferLenght);
                    foreach(byte b in buffer)                                    
                        storedCnt[b]++;
                    //TODO: Recalcul position for EOF...
                    Position += bufferLenght;
                }
                return storedCnt;
            }
            return null;
        }

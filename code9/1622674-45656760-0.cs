        public Dictionary<int, long> GetByteCount()
        {
            if (IsOpen)
            {
                Position = 0;
                int bufferLenght = 131072; //128k
                byte[] buffer;
                // Build dictionary
                Dictionary<int, long> cd = new Dictionary<int, long>();
                for (int i = 0; i <= 255; i++) cd.Add(i, 0);
                //
                
                while (!EOF)
                {
                    buffer = new byte[bufferLenght];
                    Read(buffer, 0, bufferLenght);
                    foreach(byte b in buffer)                                    
                        cd[b]++;
                    //TODO: calcul position for not reach EOF
                    Position += bufferLenght;
                }
                return cd;
            }
            return new Dictionary<int, long>();
        }

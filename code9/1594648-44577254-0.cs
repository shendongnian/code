        const int PrefixSize = 4;
        bool prefixSet = false;
        public int DataSize = 0; 
        int RecLength = 0;
        byte[] Received = new byte[2048];
 
           try {
                int dataRead = socket.EndReceive(ar);
                if (dataRead > 0) {
                    Buffer.BlockCopy(buffer, 0, Received, RecLength , dataRead);
                    RecLength += dataRead;
                    if (RecLength >= PrefixSize) {
                        if (!prefixSet) {
                            prefixSet = true;
                            DataSize = BitConverter.ToInt32(Received, 0);
                        }
                        if (RecLength >= DataSize) {
                            RecLength = 0; prefixSet = false; 
                            byte[] data = new byte[DataSize];
                            Buffer.BlockCopy(Received, 4, data, 0, DataSize);
                            ReceiveNextMessage();
                            Message m = new Message(this, data);
                        }
                        else {
                            ReceiveNextMessage();
                        }
                    }
                    else {
                        ReceiveNextMessage();
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

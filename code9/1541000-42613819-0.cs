        //Declare some public variables for serial port reading
        public byte[] headerBuff = new byte[500];
        public byte[] dataBuff = new byte[500];
        public byte[] tempBuff = new byte[500];
        public int headerBytesRead = 0;
        public int dataBytesRead = 0;
        public const int HEADER_LENGTH = 10;
        public int dataInd;
        public int fullMsgLen;
        public byte[] queuePop;
        //Declare some states
        public bool READ_HEADER = true;
        //Where will we store the data log?
        public string defDataDir;
        //Declare a public queue as a FIFO for incoming serial data once the 
        // buffer is full
        ConcurrentQueue<byte[]> serialQ = new ConcurrentQueue<byte[]>();
       //private void si_DataReceived(byte[] data)
        private void si_DataReceived(object s, EventArgs e)
        {
            //If we're supposed to read the headers, do that
            if(READ_HEADER)
            {
                //Read some bytes
                var numBytesRead = comport.Read(tempBuff, 0, comport.BytesToRead);
                //Any time we call comport.Read, we automatically log those bytes to a file
                using (BinaryWriter writer = new BinaryWriter(File.Open(defDataDir, FileMode.Append)))
                    writer.Write(tempBuff.Skip(0).Take(numBytesRead).ToArray());
                //Add these bytes to a header array
                Array.Copy(tempBuff, 0, headerBuff, headerBytesRead, numBytesRead);
                //Increment headerBytesRead counter
                headerBytesRead += numBytesRead;
                //Loop through header and see if we have a header
                if(headerBytesRead>=HEADER_LENGTH)
                {
                    //Loop through all the header bytes read so far
                    for(int i=0; i<headerBytesRead;i++)
                    {
                        //Look for the header start word.  Note, 3rd bool statement
                        // here is to make sure we have enough bytes left to identify a header
                        // e.g. read 12 bytes, and bytes 11 and 12 are 0xF9 and 0x89, then we 
                        // clearly don't have the rest of the header (since it is length 10)
                        if(headerBuff[i]==0xF9 && headerBuff[i+1]==0x89 && (headerBytesRead-i-1)>=9)
                        {
                            //We have identified a header, and have enough following characters to save it
                            //Copy the header into the data array
                            Array.Copy(headerBuff, i, dataBuff, 0, headerBytesRead - i);
                            dataInd = headerBytesRead - i;
                            //Save the message length
                            fullMsgLen = dataBuff[4]*2 + HEADER_LENGTH;
                            //Switch over to reading data
                            READ_HEADER = !READ_HEADER;
                            //Reset our header length counter
                            headerBytesRead = 0;
                            //Clear the header buffer for next time
                            Array.Clear(headerBuff, 0, headerBuff.Length); 
                            break; // don't need to look for headers anymore
                        }
                    }
                }
            }
            //Handle reading data into buffer here
            else if (!READ_HEADER)
            {
                //We've just been told to start reading data bytes, and we know how many
                var numBytesRead = comport.Read(tempBuff, 0, comport.BytesToRead);
                //Any time we call comport.Read, we automatically log those bytes to a file
                using (BinaryWriter writer = new BinaryWriter(File.Open(defDataDir, FileMode.Append)))
                    writer.Write(tempBuff.Skip(0).Take(numBytesRead).ToArray());
                //Add these bytes into the data array
                Array.Copy(tempBuff, 0, dataBuff, dataInd+dataBytesRead, numBytesRead);
                //Increment our data array counter
                dataBytesRead += numBytesRead;
                //Check to see if we have saved enough
                if((dataInd+dataBytesRead) >= fullMsgLen)
                {
                    //Copy the header+msg into the queue
                    serialQ.Enqueue(dataBuff.Skip(0).Take(fullMsgLen).ToArray());
                    //Copy the remaining bytes back into the header buffer
                    Array.Copy(dataBuff, fullMsgLen, headerBuff, 0, dataInd + dataBytesRead - fullMsgLen);
                    headerBytesRead = dataInd + dataBytesRead - fullMsgLen;
                    //Reset data bytes read countery
                    dataBytesRead = 0;
                    //Switch back to looking for headers
                    READ_HEADER = !READ_HEADER;
                }
            }
          
        }

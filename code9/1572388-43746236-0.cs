    public class SocketState
    {
        private readonly List<byte> _messageBuffer = new List<byte>(BufferSize);
        //...
        /// <summary>
        /// Async Receive Callback
        /// </summary>
        /// <param name="ar"></param>
        public static void ReadCallback(IAsyncResult ar)
        {
            SocketState tmpRef = null;
            try
            {
                if (ar != null)
                {
                    tmpRef = (SocketState)ar.AsyncState;
                    if (tmpRef != null)
                    {
                        // Read data from the client socket. 
                        int bytesRead = tmpRef.WorkSocket.Client.EndReceive(ar);
                        if (bytesRead > 0)
                        {
                            //Loop over the bytes we received this read
                            for (var i = 0; i < bytesRead; i++)
                            {   
                                //Copy the bytes from the receive buffer to the message buffer.
                                tmpRef._messageBuffer.Add(tmpRef._receiveBuffer[i]);
                                // Check if we have a complete message yet
                                if (tmpRef._receiveBuffer[i] == 160)
                                {
                                    //Copy the bytes to a tmpBuffer to be passed on to the callback.
                                    var tmpBuffer = tmpRef._messageBuffer.ToArray();
                                    //Execute callback
                                    tmpRef._receievCallbackAction(tmpBuffer);
                                    //reset the message buffer and keep reading the current bytes read
                                    tmpRef._messageBuffer.Clear();
                                }
                            }
                            //Start Reading Again
                            tmpRef.BeginReading(tmpRef._receievCallbackAction);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (tmpRef != null)
                {
                    //Call callback with null value to indicate a failier
                    tmpRef._receievCallbackAction(null);
                }
            }
        }
    //...

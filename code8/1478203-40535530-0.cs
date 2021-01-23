        public void ReceiveAsync()
        {
           socket.BeginReceive(tempBytes, 0, tempBytes.Length, 0, ReadCallback, this);//immediately returns 
        }
        
        private void ReadCallback(IAsyncResult ar)//is called if something is received in the buffer as well as if other side closed connection - in this case countBytesRead will be 0
        {
           int countBytesRead = handler.EndReceive(ar);
           if (countBytesRead > 0)
           {
               //read tempBytes buffer
           }
        }
  

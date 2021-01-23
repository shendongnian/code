    class MyConnection : IDisposable
    {
        ShellStream myStream = client.CreateShellStream(...);//it represents Stream between client and server, create it as single instance for each calling SendCommand
    
        void SendCommand(string command)
        {
            myStream.WriteLine(command);//send a command to server
            string readed = null;
            while (myStream.DataAvailable)
            {
                output = myStream.Read();//get data from server
            }
        }
    
        public void Dispose()  
        {  
            Dispose(true);  
            GC.SuppressFinalize(this);  
        } 
    
        protected virtual void Dispose(bool disposing)  
        {  
            if (disposing)   
            {  
                // free managed resources  
                if myStream != null)  
                {  
                    myStream .Dispose();  
                    myStream = null;  
                }  
            }  
        }  
    }

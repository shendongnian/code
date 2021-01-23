    private static void run(){
        while (running){
            try{
                byte[] prefBuffer = new byte[100];
                int bufferSize = clientSocket.Receive(prefBuffer);
                writeMsg(">> Data recieved from client");
                for (int i = 0; i < bufferSize; i++){
                    Console.Write(Convert.ToChar(prefBuffer[i]));
                }
            }
            catch{
                writeMsg("Connection Lost");
                running = false;
                clientListener.Stop();
                clientSocket.Close();
                waitForConnection();
                break;
            }
        }
        runThread.Abort();
    }

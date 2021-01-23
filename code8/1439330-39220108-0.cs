     void OnDisable()
     {
         if (udpListeningThread != null && udpListeningThread.IsAlive)
         {
             udpListeningThread.Abort();
         }
    
         receivingUdpClient.Close();
     }

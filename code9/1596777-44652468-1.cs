        private Object responseSignal = new object();
        private string portResponse;
       _session.DataReceived += new SerialDataReceivedEventHandler(PortDataReceived);
    static string GetData(int memoryAddress)
    {
       if (!_session.IsOpen)
         return "No Connection";
       string toSend = "*A_r_" + memoryAddress.ToString() + "_0" + (char)21;
       foreach (char character in toSend)
         _session.Write(character.ToString());
      if (System.Threading.Monitor.Wait(responseSignal, 10000)) // max time we want to wait to receive the response
       {
           // successful get
       }   
       else
       {
           //  failed to receive the response 
        }
        return portResponse;
      }
      public void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (responseSignal)
                {
                    string tmpPortResponse = _session.ReadExisting();
                    portResponse += tmpPortResponse;
                    
                    
                    //Complete the response only when you get the end character
                    if (tmpPortResponse.Contains('.'))
                    {
                        // signal allows a waiting SendMessage method to proceed
                        System.Threading.Monitor.Pulse(responseSignal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

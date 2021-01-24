     public void sendData(byte[] bytestosend)
            {
              _serialPort.Open();
                StartListening();
                _serialPort.Write(bytestosend, 0, bytestosend.Length);
    
               System.Threading.Thread.Sleep(500);
            }

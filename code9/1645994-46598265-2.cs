        public void sendData(string msg)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    
                    //serialPort.Close();
                }
                if (serialPort.IsOpen)
                {
                    serialPort.Write(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

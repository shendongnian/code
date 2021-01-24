    private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if(mySerialPort.IsOpen)
      {
        mySerialPort.Close();
      }
    }

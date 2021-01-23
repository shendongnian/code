    char[] lxCMD = new char[8];
    var bytesRead = 0; 
    .
    .
    .
    
    private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      bytesRead = serialPort.Read(lxCMD, 0, lxCMD.Length);
      this.Invoke(new EventHandler(UpdateVar));
            }
    
    private void UpdateVar(object sender, EventArgs e)
    {
      string strRecieved = "Ack";
      if (lxCMD[0] != 0x6)
      {
        strRecieved = new string(lxCMD);
        strRecieved = strRecieved.SubString(0, bytesRead)
      }
      textBox1.AppendText(strRecieved);  // This line prints :GS# correctly!
      textBox1.AppendText(Environment.NewLine);
      switch(strRecieved)
        {
          case ":GS#":
              serialPort.Write("20:08:18#");
              textBox1.AppendText("1:");  
              textBox1.AppendText(Environment.NewLine);
                  break;
           case "Ack":
              serialPort.Write("1");
              textBox1.AppendText("2:");
              textBox1.AppendText(Environment.NewLine);
                  break;
           default:
              textBox1.AppendText("Nothing");
                  break;
    
                }
    
            }

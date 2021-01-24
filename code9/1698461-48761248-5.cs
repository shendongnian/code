    private void OpenPort()
    {
          private System.IO.Ports.SerialPort ComPort;
           ComPort= new System.IO.Ports.SerialPort("COM1");//depends on your 
         Device COM
                ComPort.NewLine = System.Environment.NewLine;
                ComPort.BaudRate = 115200;
                ComPort.Parity = System.IO.Ports.Parity.None;
                ComPort.DataBits = 8;
                ComPort.StopBits = System.IO.Ports.StopBits.One;
                ComPort.Handshake = System.IO.Ports.Handshake.None;
                ComPort.ReadTimeout = 3600000;
                ComPort.WriteTimeout = 3600000;
                ComPort.Encoding = Encoding.GetEncoding("iso-8859-1");
                GC.SuppressFinalize(ComPort);
                SerialPortFixer.Execute("COM1");
                ComPort.DataReceived += 
                    new 
       System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
                ComPort.Open();
                GC.SuppressFinalize(ComPort.BaseStream);
                ComPort.DtrEnable = true;
                ComPort.RtsEnable = true;
       }

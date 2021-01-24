    void InitialComport1()
            {
    
                mySerialPort1 = new SerialPort(Temp._comport1);
                if (mySerialPort1.IsOpen)
                {
                    mySerialPort1.Close();
                }
                mySerialPort1.BaudRate = Temp._baudRate1;
                mySerialPort1.Parity = Parity.None;
                mySerialPort1.StopBits = StopBits.One;
                mySerialPort1.DataBits = Temp._dataBit1;
                mySerialPort1.Handshake = Handshake.None;
                mySerialPort1.RtsEnable = true;
                mySerialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
                try
                {
                    mySerialPort1.Open();
                }
                catch
                {
                    Messagebox.Show("Error myserialPort1")
                }
            }
    private void DataReceivedHandler1(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string indata = mySerialPort1.ReadLine();
                try
                {
                    string mass = indata.Substring(7, 7);
                    SetText1((Convert.ToInt32(mass)).ToString());
                }
                catch
                {
                    string mass = indata.Substring(3, 7);
                    SetText1((Convert.ToInt32(mass)).ToString());
                }
            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.ToString());
            }
        }

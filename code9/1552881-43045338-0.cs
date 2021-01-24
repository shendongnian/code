    public void RFID_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort RFID = (SerialPort)sender;
        int buffer = RFID.ReadBufferSize;
        byte[] data = new byte[buffer];
        RFID.Read(data, 0, buffer);
        string s = "";
        for (int i = 0; i < 18; i++)
        {
            s += Convert.ToString(data[i], 16);
            if (i % 2 > 0)
                s += " ";
        }
        s += Environment.NewLine;
        textBox1.Invoke(this.myDelegate, new Object[] { s });
    }

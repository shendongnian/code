    private void button1_Click(object sender, EventArgs e)
    {
        //<-- This block ensures that no exceptions happen
        if (_serialPort1 != null && _serialPort1.IsOpen)
            _serialPort1.Close();
        if (_serialPort1 != null)
           _serialPort1.Dispose();
        //<-- End of Block
        // Adding port back to the comboBox as it is not open now.
        comboBox.Items.Add(_serialPort1.PortName);
        if (comboBox2.Text != "")
        {
            _serialPort1 = new SerialPort(comboBox2.Text, BaudRate, Parity.Even, 7, StopBits.Two);       //<-- Creates new SerialPort using the name selected in the combobox
            _serialPort1.DataReceived += SerialPortOnDataReceived;       //<-- this event happens everytime when new data is received by the ComPort
            _serialPort1.Open();     //<-- make the comport listen
            
            //removing port from the comboBox as it is now open and in-use.
            comboBox2.Items.Remove(comboBox2.Text);
            button1.Enabled = false;
            button2.Enabled = true;
     }

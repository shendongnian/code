        private void comboBox9_DropDown(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();     //<-- Reads all available comPorts
            foreach (var portName in portNames)
            {
                comboBox9.Items.Add(portName);
            }
            if (_serialPort1 != null && _serialPort1.IsOpen)
            {
                comboBox9.Items.Remove(_serialPort1.PortName);
            }
        }

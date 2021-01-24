                /// <summary>
                /// Connects to a serial port defined through the current settings
                /// </summary>
                public void StartListening()
                {
                    // Closing serial port if it is open
                    if (_serialPort != null && _serialPort.IsOpen)
                            _serialPort.Close();
        
                // Setting serial port settings
                _serialPort = new SerialPort(
                    _currentSerialSettings.PortName,
                    _currentSerialSettings.BaudRate,
                    _currentSerialSettings.Parity,
                    _currentSerialSettings.DataBits,
                    _currentSerialSettings.StopBits);
    
                // Subscribe to event and open serial port for data
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.Open();
            }

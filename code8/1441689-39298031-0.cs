    public SerialPort(System.ComponentModel.IContainer container)
    {
        container.Add(this);
    }
    public SerialPort()
    {
    }
    // Non-design SerialPort constructors here chain, 
    //using default values for members left unspecified by parameters
    public SerialPort(string portName) 
        : this (portName, defaultBaudRate, defaultParity, defaultDataBits, defaultStopBits)
    {
    }
    public SerialPort(string portName, int baudRate) 
        : this (portName, baudRate, defaultParity, defaultDataBits, defaultStopBits)
    {
    }
    public SerialPort(string portName, int baudRate, Parity parity)
        : this (portName, baudRate, parity, defaultDataBits, defaultStopBits)
    {
    }
    public SerialPort(string portName, int baudRate, Parity parity, int dataBits)
        : this (portName, baudRate, parity, dataBits, defaultStopBits)
    {
    }
    public SerialPort(string portName, int baudRate, Parity parity, 
         int dataBits, StopBits stopBits)
    {
        this.PortName = portName;
        this.BaudRate = baudRate;
        this.Parity = parity;
        this.DataBits = dataBits;
        this.StopBits = stopBits;
    }

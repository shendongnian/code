    /// <summary>
    /// Read data from Arduino until user presses key.
    /// </summary>
    /// <param name="args">Arguments to the program (we do not take any).</param>
    static void Main(string[] args)
    {
        SerialPort port;
    
        // first, create a new serial-port
        port = new SerialPort();
    
        // configure the settings to match the Arduino board
        // below i've just used some of the most common settings
        // to get the point across
        port.BaudRate = 9600;
        port.DataBits = 8;
        port.StopBits = StopBits.One;
        port.Parity = Parity.None;
    
        // you'll have to figure out what your actual COM name is
        // for this example I'll just use COM 11
        port.PortName = "COM1";
    
        // subscribe to when the data is coming from the port
        port.DataReceived += Port_DataReceived;
    
        // open up communications with the port
        port.Open();
    
        // continue to receive data until user presses key
        Console.ReadKey();
    }

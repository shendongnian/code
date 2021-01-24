    public class SerialConnection
    {
        INIFile settings = new INIFile("C:\\Lateco\\settings.ini");
        public SerialPort SerialPort { get; set; }
        static SerialConnection connection= null;
        public event EventHandler WeightReceived;
     
        public static SerialConnection OpenConnection()
        {
            if(connection == null)
            {
                connection = new SerialConnection();
                string portname, baudrate, parity, databits, stopbits, handshake;
    
                portname = settings.Read("SERIAL PORT PROPERTIES", "PORT_NAME");
                baudrate = settings.Read("SERIAL PORT PROPERTIES", "BAUD_RATE");
                parity = settings.Read("SERIAL PORT PROPERTIES", "PARITY");
                databits = settings.Read("SERIAL PORT PROPERTIES", "DATA_BITS");
                stopbits = settings.Read("SERIAL PORT PROPERTIES", "STOP_BITS");
                handshake = settings.Read("SERIAL PORT PROPERTIES", "HANDSHAKE");
    
                connection.SerialPort = new SerialPort(); //error here
                connection.SerialPort.PortName = portname;
                connection.SerialPort.BaudRate = int.Parse(baudrate);
                connection.SerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity, true);
                connection.SerialPort.DataBits = int.Parse(databits);
                connection.SerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopbits, true);
                connection.SerialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true);
    
                connection.SerialPort.Open();
                connection.SerialPort.ReadTimeout = 200;
                connection.SerialPort.DataReceived += new SerialDataReceivedEventHandler(connection.serialPort1_DataReceived);
            }
    
            private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                try
                {
                    weight = SerialPort.ReadExisting();
                    weight = weight.Substring(0, 7);
    
                    WeightReceived?.Invoke(weight, new EventArgs());
                }
                catch (TimeoutException) { }
            }
    
            return connection;
        }
    
        public void CloseConnection()
        {
            if (SerialPort.IsOpen)
                    SerialPort.Close();
        }
    
        ~SerialConnection()
        {
            if (SerialPort.IsOpen)
                    SerialPort.Close();
        }
    }
    

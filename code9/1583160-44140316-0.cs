    public static void ConnectToArduino()
    {
        try
        {
            Arduino window = Application.Current.Windows.OfType<Arduino>().FirstOrDefault();
            string portName = window.tboxPortName.Text;
            sp.PortName = portName;
            sp.BaudRate = 9600;
            sp.Open();
            window.DisplayConnected();
            isConnected = true;
        }
        catch (Exception)
        {
            System.Windows.MessageBox.Show("Please give a valid port number or check your connection. " +
                "If the port number is correct but the error persist, please check if your Arduino device is correctly connected.");
        }
    }
    public static void DisconnectFromArduino()
    {
        try
        {
            sp.Close();
            isConnected = false;
            Arduino window = Application.Current.Windows.OfType<Arduino>().FirstOrDefault();
            window.DisplayDisconnected();
        }
        catch (Exception)
        {
            System.Windows.MessageBox.Show("In order to disconnect, you have to connect first to an Arduino device.");
        }
    }

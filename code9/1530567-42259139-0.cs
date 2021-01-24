    System.Windows.Threading.DispatcherTimer MyTimer = null;
    private void ReceiveData()
    {
        MyTimer = new System.Windows.Threading.DispatcherTimer();
        MyTimer.Interval = new TimeSpan(0, 0, 0, 500);
        MyTimer.Tick += MyTimer_Tick;
        SerialPort serialPort = new SerialPort("COM1", 9600);
        serialPort.DataReceived += new 
                 SerialDataReceivedEventHandler(DataReceivedHandler);
        serialPort.Open();
    }
    
    private static void DataReceivedHandler(
                    object sender,
                    SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        if (indata.Contains(" "))
        {
            testString = indata.Substring(0, 4);
    
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        ReceiveData();
    }
    private void MyTimer_Tick(object sender, EventArgs e)
    {
        if (testString == "x1-1") EllipseBrush = Brushes.Blue;
        else EllipseBrush = Brushes.Red;
    }

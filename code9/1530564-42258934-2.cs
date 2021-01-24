    class MyCommPort : INotifyPropertyChanged
    {
        SerialPort serialPort = null;
        public MyCommPort()
        {
            serialPort = new SerialPort("COM3", 9600);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();
        }
        ~MyCommPort()
        {
            serialPort.Close();
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string testString = null;
            string indata = sp.ReadLine();
            if (indata.Length >= 4)
            {
                testString = indata.Substring(0, 4);
                // Update the value
                if (testString == "x1-1") EllipseBrush = Brushes.Blue;
                else EllipseBrush = Brushes.Red;
            }
            Console.Write(testString);
        }
            
        // Create a property that will be bound
        private SolidColorBrush ellipseBrush = Brushes.Red;
        public SolidColorBrush EllipseBrush
        {
            get { return ellipseBrush; }
            set
            {
                ellipseBrush = value;
                OnPropertyChanged("EllipseBrush");
            }
        }
        // Extend the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // Alert anyone bound to this that the value has changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class MyCommPort : INotifyPropertyChanged {
        // Create a property that will be bound
        private SolidColorBrush ellipseBrush = Brushes.Red;
        public Brush EllipseBrush {
            get {return ellipseBrush;}
            set {
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
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (indata.Contains(" "))
            {
                testString = indata.Substring(0, 4);
                // Update the value
                if (testString == "x1-1") EllipseBrush = Brushes.Blue;
                else EllipseBrush = Brushes.Red;
            }
            Console.Write(indata);
        }

    public class SerialPortsColorReadWriteXML:INotifyPropertyChanged
    {
        private SerialPortsColors _LSerialPortsColors;
        public SerialPortsColorReadWriteXML()
        {
            _LSerialPortsColors = new SerialPortsColors();
        }
        public SerialPortsColors LSerialPortsColors
        {
            get
            {
                return _LSerialPortsColors;
            }
            set
            {
                _LSerialPortsColors = value;
                OnProperyChanged("LSerialPortsColors");
            }
        }
        private  string path = "SerialPortsColors.xml";        
        /// <summary>
        /// read the serial ports color XML
        /// </summary>
        /// <returns>In Case of an error return the error</returns>
        public  string ReadXML()
        {            
            XmlSerializer serializer = new XmlSerializer(typeof(SerialPortsColors));
            try
            {
                using (XmlReader reader = XmlReader.Create(path))
                {
                    LSerialPortsColors = (SerialPortsColors)serializer.Deserialize(reader);                    
                }
                return "";
            }
            catch  (Exception )
            {
                return "There is an issue with the path of the Serial Ports Color XML";
            }
            
            
        }
        public  string WriteXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SerialPortsColors));
            try
            {
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, xws))
                {
                    serializer.Serialize(writer, LSerialPortsColors);
                }
                return "";
            }
            catch
            {
                return  "There is an issue Creating a new XML File";
            }            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnProperyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

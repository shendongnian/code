    [Serializable, XmlRoot("configuration")]
    public class Configuration : IDataErrorInfo, INotifyPropertyChanged
    {
        private int _minute;
        [XmlElement]
        public int minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                this.Save();
                OnPropertyChanged("minute");
            }
        }
        [XmlIgnore]
        public bool loaded;
        public static Configuration Load()
        {
        string ConfigPath= AppDomain.CurrentDomain.BaseDirectory + "config.xml";
        if (File.Exists(ConfigPath))
        {
            try
            {
                XmlSerializer _s = new XmlSerializer(typeof(Configuration));
                var tempConf = (Configuracion)_s.Deserialize(new XmlTextReader(ConfigPath));
                tempConf.loaded = false;
                return tempConf;
            }
            [...]
        }
        public Configuracion()
        {
            loaded = false;
            minutes = 60;
        }
        [...]
    }

    public partial class MainWindow : Window,INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private string serializedData = string.Empty;
    
            public  ObservableCollection<Data> TreeItems {get;set;}
    
            public string SerializedData
            {
                get
                {
                    return serializedData;
                }
                set
                {
                    serializedData = value;
                    NotifyPropertyChanged();
                }
            }
           
            public MainWindow()
            {
                InitializeComponent();
    
                TreeItems=new ObservableCollection<Data>();
                TreeItems.Add(new Data()
                {
                    Name = "Root",
                    SubItems = new ObservableCollection<Data>()
                    {
                      new Data(){Name="Child1"},
                      new Data(){Name="Child2"}
                    }
                    
                });
    
                this.DataContext=this;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                SerializedData = Serialize<ObservableCollection<Data>>(TreeItems);
            }
    
    
            public string Serialize<T>(T value)
            {
                if (value == null)
                {
                    return string.Empty;
                }
                try
                {
                    var xmlserializer = new XmlSerializer(typeof(T));
                    var stringWriter = new StringWriter();
                    using (var writer = XmlWriter.Create(stringWriter))
                    {
                        xmlserializer.Serialize(writer, value);
                        return stringWriter.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred", ex);
                }
            }
    
    
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            
        }
    
        public class Data : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private string name = string.Empty;
           
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
    
            [XmlArrayItem("SubItem")]  
            public ObservableCollection<Data> SubItems { get; set; }
    
            
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

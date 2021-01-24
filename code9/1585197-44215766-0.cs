    public class MyWindow : Window
    {
        public ObservableCollection<MyObject> MyObjects {get; } = new ObservableCollection<MyObject>();
        public MyWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public void Button_Click(object sender, EventArgs e)
        {
            MyObjects.Add(new MyObject { Title = "Hi there" });
        }
    }
    public class MyObject : INotifyPropertyChanged
    {
         private string _title;
         
         public string Title
         {
             get { return _title;}
             set
             {
                 if(_title!= value)
                 {
                     _title = value;
                     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs( nameof(Title)));
                 }
             }
         }
         public event PropertyChangedEventHandler PropertyChanged;
    }
    <ListBox ItemsSource="{Binding MyObjects}" />

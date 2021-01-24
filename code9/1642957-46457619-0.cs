     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = objviewmodel;
            objviewmodel.ImagePath = @"/ImageLoading;component/Assets/Desert.jpg"; // your image path
         
        }
        viewmodel objviewmodel = new viewmodel();
        
    }
    public class viewmodel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChanged([CallerMemberName] string PropertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion
        private string _ImagePath=string.Empty;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; OnpropertyChanged(); }
        }
    }

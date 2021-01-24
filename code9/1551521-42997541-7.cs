    namespace WpfApplication29
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MainViewModel();
            }
        }
    
        public class MainViewModel : INotifyPropertyChanged
        {
            public LinqViewModel LinqModel
            {
                get; set;
            } = new LinqViewModel();
    
            public MainViewModel()
            {
                SelectedMainModel = LinqModel;
            }
            private object selectedModel;
            public object SelectedMainModel
            {
                get
                {
                    return selectedModel;
                }
                set
                {
                    selectedModel = value;
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void Notify(string name)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public class LinqViewModel : INotifyPropertyChanged
        {
            public UserModel UserModel
            {
                get; set;
            } = new UserModel();
    
            private object selectedChildModel;
            public object SelectedChildModel
            {
                get
                {
                    return selectedChildModel;
                }
                set
                {
                    selectedChildModel = value;
                    Notify("SelectedChildModel");
                }
    
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void Notify(string name)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public class UserModel
        {
    
        }
    }

    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApplication4
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
     
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new ContentViewModel() { Content = "foo" };
            }
        }
    
        public class ContentViewModel : ViewModelBase
        {
            private string _toogleActionName = "turn it off";
            private bool _isContentVisible = true;
            private string _content;
            public bool IsContentVisible
            {
                get
                {
                    return _isContentVisible;
                }
                set
                {
                    _isContentVisible = value;
    
                    //switch action name
                    if (value)
                        ToogleActionName = "turn it off";
                    else
                        ToogleActionName = "turn it on";
    
                    OnPropertyChanged();
                }
            }
          
            public string Content
            {
                get
                {
                    return _content;
                }
                set
                {
                    _content = value;
                    OnPropertyChanged();
                }
            }
    
            public string ToogleActionName
            {
                get
                {
                    return _toogleActionName;
                }
                set
                {
                    _toogleActionName = value;
                    OnPropertyChanged();
                }
            }
    
        }
    
    
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }

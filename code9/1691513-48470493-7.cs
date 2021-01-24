    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace WpfTest
    {
        /// <summary>
        /// Interaction logic for MainPage.xaml
        /// </summary>
        public partial class MainPage : Page, INotifyPropertyChanged
        {
            private Brush bCol;
            public System.Windows.Media.Brush BCol
            {
                get { return bCol; }
                set
                {
                    bCol = value; 
                    RaisePropertyChanged("BCol");
                }
            }
            public MainPage()
            {
                InitializeComponent();
                DataContext = this; //This is a hack, you should really create a separate view model
                BCol=new SolidColorBrush(Colors.Blue);
            }
            public event PropertyChangedEventHandler PropertyChanged= delegate { };
            void RaisePropertyChanged(string name)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }
    }

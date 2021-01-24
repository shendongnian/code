    namespace WpfApplication5
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public static Person oPerson;
    
            public MainWindow()
            {
                InitializeComponent();
                oPerson = this.Resources["personData"] as Person;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                txtFreedom.Text = oPerson.Name;
            }
        }
    
        public class Person : INotifyPropertyChanged
        {
            string name;
            public string Name
            {
                get { return this.name; }
                set
                {
                    this.name = value;
                    OnPropertyChanged("Name");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    namespace WpfApp2
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private bool _someProperty;
            public bool SomeProperty
            {
                get { return _someProperty; }
                set
                {
                    _someProperty = value;
                    OnPropertyChanged();
                }
            }
            public MainWindow()
            {
                DataContext = this;
                InitializeComponent();
            }
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                SomeProperty = !SomeProperty;
            }
        }
    }

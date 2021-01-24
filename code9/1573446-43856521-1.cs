    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var vm = new PasswordViewModel();
            this.DataContext = vm;
            InitializeComponent();
        }
        private void MyPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pBox = sender as PasswordBox;
            PasswordBoxMVVMAttachedProperties.SetEncryptedPassword(pBox, pBox.SecurePassword);    
        }
        private void PasswordBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pBox = sender as PasswordBox;
            if (pBox.IsEnabled == false)
            {
                RoutedEventArgs eventArgs = new RoutedEventArgs(PasswordBoxAttachedEvent.HasBeenDisabledEvent);
                pBox.RaiseEvent(eventArgs);
            }
            if (pBox.IsEnabled == true)
            {
                RoutedEventArgs eventArgs = new RoutedEventArgs(PasswordBoxAttachedEvent.HasBeenEnabledEvent);
                pBox.RaiseEvent(eventArgs);
            }
        }
    }
